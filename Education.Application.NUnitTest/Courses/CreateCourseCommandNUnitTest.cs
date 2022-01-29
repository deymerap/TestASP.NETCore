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
    public class CreateCourseCommandNUnitTest
    {
        private CreateCourseCommand.CreateCourseCommandHandler handlerCreateCourse;

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
            handlerCreateCourse = new CreateCourseCommand.CreateCourseCommandHandler(EducatioDBContextFake);

        }


        [Test]
        public async Task CreateCourseCommandHandler_ReturnNumber()
        {
            CreateCourseCommand.CreateCourseCommandRequest request = new()
            {
                Description = "Curso de test y validar funcionamiento.",
                Title = "Curso de test",
                PublishedDate = DateTime.Now.AddDays(360),
                Price = 1999
            };

            var vResult = await handlerCreateCourse.Handle(request, new CancellationToken());

            Assert.AreEqual(vResult, MediatR.Unit.Value);
        }

    }
}
