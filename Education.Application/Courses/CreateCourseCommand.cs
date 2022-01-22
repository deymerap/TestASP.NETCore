using AutoMapper;
using Education.Domain;
using Education.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Courses
{
    public  class CreateCourseCommand
    {

        public class CreateCourseCommandRequest : IRequest
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime? PublishedDate { get; set; }
            public Decimal Price { get; set; }
        }

        public class CreateCourseCommandRequestValidation : AbstractValidator<CreateCourseCommandRequest>
        {
            public CreateCourseCommandRequestValidation()
            {
                RuleFor(x => x.Description);
                RuleFor(x => x.Title);
            }

        }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommandRequest>
        {
            private readonly EducatioDBContext _educationDBContext;
            public CreateCourseCommandHandler(EducatioDBContext vDBContext)
            {
                _educationDBContext = vDBContext;
            }
        

            public async Task<Unit> Handle(CreateCourseCommandRequest request, CancellationToken cancellationToken)
            {
                var vObCourse = new Course
                {
                    CourseId = Guid.NewGuid(),
                    Description = request.Description,
                    Title = request.Title,
                    CreatedDate = DateTime.UtcNow,
                    PublishedDate = request.PublishedDate,
                    Price = request.Price
                };

                _educationDBContext.Add(vObCourse);
                var vReturnOP =  await _educationDBContext.SaveChangesAsync();

                if (vReturnOP > 0)
                    return Unit.Value;

                throw new Exception("Could not add course.");
            }
        }



    }
}
