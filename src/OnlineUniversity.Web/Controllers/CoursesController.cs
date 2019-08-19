using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineUniversity.Application.Courses.Commands.CreateCourse;
using OnlineUniversity.Application.Courses.Commands.SignUpCourse;
using OnlineUniversity.Application.Courses.Queries;
using System;
using System.Threading.Tasks;

namespace OnlineUniversity.Web.Controllers
{
    [ApiController, Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var getCourseQuery = new GetCourseQuery
            {
                Id = new Guid(id)
            };

            return Ok(await _mediator.Send(getCourseQuery));
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> Post([FromBody]CreateCourseDto createCourseDto)
        {
            var createCourseCommand = new CreateCourseCommand
            {
                Name = createCourseDto.Name,
                Capacity = createCourseDto.Capacity,
                LecturerId = createCourseDto.LecturerId
            };

            return Ok(await _mediator.Send(createCourseCommand));
        }

        [HttpPost, Route("sign-up")]
        public async Task<IActionResult> Post([FromBody] SignUpToCourseRequestDto request)
        {
            var signUpToCourseCommand = new SignUpToCourseCommand
            {
                CourseId = new Guid(request.CourseId),
                StudentEmail = request.Student.Email,
                StudentFullName = request.Student.Name
            };

            return Ok(await _mediator.Send(signUpToCourseCommand));
        }
    }
}
