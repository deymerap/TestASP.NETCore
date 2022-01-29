using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Courses
{
    [TestFixture]
    public class GetCourseQueryNUnitTest
    {
        private GetCourseQuery.GetCourseQueryHandler handlerAllCourse;
        
        [SetUp]
        public void init()
        {
            var fixture = new Fixture();
            var courseRecords = fixture.CreateMany<Course>().ToList();
            courseRecords.Add(
                fixture.Build<Course>()
                .With(x => x.CourseId, Guid.Empty)
                .Create()
                );

            var options = new DbContextOptionsBuilder<EducatioDBContext>()
                            .UseInMemoryDatabase(databaseName: $"EducatioDBContext-{Guid.NewGuid()}")
                            .Options;
            var EducatioDBContextFake = new EducatioDBContext(options);
            EducatioDBContextFake.Courses.AddRange(courseRecords);
            EducatioDBContextFake.SaveChanges();

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();
            handlerAllCourse = new GetCourseQuery.GetCourseQueryHandler(EducatioDBContextFake, mapper);

        }
        
        [Test]
        public async Task GetCourseQueryHandler_ConsultaCursos_ReturnTrue()
        {
            //1. Emular al Context que respresenta la instancia de EntityFramework
            //2. Emular al Mapping Profile
            //3. Instanciar un objeto de la clase GetCourseQuery.GetCourseQueryHandler y pasarle
            // como instancia los objetos Mapping y context

            GetCourseQuery.GetCourseQueryRequest request = new();
            var vResult = await handlerAllCourse.Handle(request, new CancellationToken());

            Assert.IsNotNull(vResult);
        }
    }
}
