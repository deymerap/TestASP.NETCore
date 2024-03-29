﻿using Education.Application.Courses;
using Education.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> Get()
        {
            return await _mediator.Send(new GetCourseQuery.GetCourseQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(string id)
        {
            GetCourseByIdQuery.GetCourseByIdQueryRequest request = new() { Description = id };
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(CreateCourseCommand.CreateCourseCommandRequest request)
        {

            return await _mediator.Send(request);
        }
    }
}
