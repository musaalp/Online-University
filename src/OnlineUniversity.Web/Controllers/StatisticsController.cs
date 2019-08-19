using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineUniversity.Application.Statistics.Queries;
using System.Threading.Tasks;

namespace OnlineUniversity.Web.Controllers
{
    [ApiController, Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetStatisticsQuery()));
        }
    }
}
