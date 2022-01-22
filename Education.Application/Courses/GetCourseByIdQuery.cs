using AutoMapper;
using Education.Application.DTOs;
using Education.Application.Mapping;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Courses
{
    public class GetCourseByIdQuery
    {
        public class GetCourseByIdQueryRequest : IRequest<CourseDto> 
        {
            public string Description { get; set; }
        }



        public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQueryRequest, CourseDto>
        {
            private readonly EducatioDBContext _educationDBContext;
            private readonly IMapper _mapper;

            public GetCourseByIdQueryHandler(EducatioDBContext vDBContext, IMapper mapper)
            {
                _educationDBContext = vDBContext;
                _mapper = mapper;
            }
            public async Task<CourseDto> Handle(GetCourseByIdQueryRequest request, CancellationToken cancellationToken)
            {
                var vObCourse = await _educationDBContext.Courses.FirstOrDefaultAsync(x => x.Description.Contains(request.Description));
                var vObCourseDTO = _mapper.Map<Course, CourseDto>(vObCourse);

                return vObCourseDTO;
            }
        }

    }


}
