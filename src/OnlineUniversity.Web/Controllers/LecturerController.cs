using Microsoft.AspNetCore.Mvc;
using OnlineUniversity.Application.Lecturer.Commands;
using System;
using System.Threading.Tasks;

namespace OnlineUniversity.Web.Controllers
{
    [ApiController, Route("[controller]")]
    public class LecturersController : ControllerBase
    {
        [HttpPost, Route("create")]
        public Task<IActionResult> Post([FromBody]CreateLecturerDto createStudentDto)
        {
            throw new NotImplementedException();
        }
    }
}
