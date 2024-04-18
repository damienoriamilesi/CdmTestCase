using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Features.CreateSampleObject;
using static SampleAPI.Controllers.SampleController;

namespace SampleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    private readonly IMediator _mediator;

    public SampleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePersonRequest request)
    {
        var createdResource = await _mediator.Send(request);
        return CreatedAtAction(nameof(Get), new { id = createdResource.Person.Id }, createdResource.Person);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var retrievedResource = _mediator.Send(new GetByIdRequest(id));
        return Ok(retrievedResource);
    }

    public abstract class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public virtual decimal Salary => 50000;
    }
}

public record GetByIdRequest(int id);

//public class FakeGenerator
//{
//    public static IEnumerable<SampleObject> GenerateSampleObjects(int count = 50)
//    {
//        for (int i = 0; i < count; i++)
//        {
//            yield return new SampleObject { Name = $"Name_{i}" };
//        }
//    }
//}