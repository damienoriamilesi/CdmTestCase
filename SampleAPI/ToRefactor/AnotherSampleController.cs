using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SampleAPI.ToRefactor
{
    [ApiController]
    [Route("[controller]")]
    public class AnotherSampleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnotherSampleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult Create([FromBody] dynamic request)
        {
            throw new NotImplementedException();
        }


        public class CreateSampleObjectRequest
        {
        }
    }
}
