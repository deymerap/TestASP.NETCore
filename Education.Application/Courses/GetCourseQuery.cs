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
    public class GetCourseQuery
    {
        public class GetCourseQueryRequest : IRequest<List<CourseDto>> { }


 
        public class GetCourseQueryHandler : IRequestHandler<GetCourseQueryRequest, List<CourseDto>>
        {
            private readonly EducatioDBContext _educationDBContext;
            private readonly IMapper _mapper;

            public GetCourseQueryHandler(EducatioDBContext vDBContext, IMapper mapper)
            {
                _educationDBContext = vDBContext;
                _mapper = mapper;
            }
            public async Task<List<CourseDto>> Handle(GetCourseQueryRequest request, CancellationToken cancellationToken)
            {
                var vObCourse = await _educationDBContext.Courses.ToListAsync();
                 var vObCourseDTO = _mapper.Map<List<Course>, List<CourseDto>>(vObCourse);

                return vObCourseDTO;
            }
        }

    }


}
