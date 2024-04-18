using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Features.CreateSampleObject;
using static SampleAPI.Controllers.SampleController;

namespace SampleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly IMediator _mediator;

    public SampleController(IConfiguration config, IMediator mediator)
    {
        _config = config;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSampleObjectRequest request)
    {
        var createdResource = await _mediator.Send(request);
        return CreatedAtAction(nameof(Get), new { id = createdResource.foo.Id }, createdResource.foo);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var retrievedResource = _mediator.Send(new GetByIdRequest(id));
        return Ok(retrievedResource);
    }

    public enum SampleObjectTypes
    {
        Sample1,
        Sample2,
        Sample3
    }

    public enum SearchCriteriaModes
    {
        Even,
        MoreThan42,
        Top21,
        All
    }

    public class SampleObject
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}

public record GetByIdRequest(int id);

public class FakeGenerator
{
    public static IEnumerable<SampleObject> GenerateSampleObjects(int count = 50)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new SampleObject { Name = $"Name_{i}" };
        }
    }
}