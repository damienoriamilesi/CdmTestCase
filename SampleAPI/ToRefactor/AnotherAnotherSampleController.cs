using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SampleAPI.ToRefactor
{
    [ApiController]
    [Route("[controller]")]
    public class AnotherAnotherSampleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnotherAnotherSampleController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public IActionResult Create([FromBody] dynamic request)
        {
            throw new NotImplementedException();
        }
    }
}
