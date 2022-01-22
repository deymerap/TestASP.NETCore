using Education.Api.ExtensionServices;
using Education.Application.Courses;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Configuration;


//public static readonly ILoggerFactory loggerFactory
//           = LoggerFactory.Create(builder =>
//           {
//               builder
//                   .AddFilter((category, level) =>
//                       category == DbLoggerCategory.Database.Command.Name
//                       && level == LogLevel.Information)
//                .AddConsole();
//           });
//public IConfiguration Configuration { get; }
//public Startup(IConfiguration configuration)
//{
//    Configuration = configuration;
//}



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var configuration = builder.Configuration;

builder.Services.ConfigureSqlServerDbContext(configuration);
builder.Services.AddMediatR(typeof(GetCourseQuery.GetCourseQueryHandler).Assembly);
builder.Services.AddAutoMapper(typeof(GetCourseQuery.GetCourseQueryHandler));
builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<CreateCourseCommand>());
builder.Services.AddCors( o => o.AddPolicy("corsApp", builder => { 
    builder.AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader();
}));


var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseCors("corsApp");

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();
app.MapControllers();
//app.UseRouting();
app.Run();
