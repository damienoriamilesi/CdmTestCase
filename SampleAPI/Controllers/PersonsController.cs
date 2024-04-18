using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Features.CreatePerson;
using SampleAPI.Features.GetPersonById;

namespace SampleAPI.Controllers;

/// <summary>
/// API to manage Persons in a company
/// </summary>
[ApiController]
[Route("[controller]")]
public class PersonsController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// MediatR injection
    /// </summary>
    /// <param name="mediator"></param>
    public PersonsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    ///  Could be a Command instead but don't mind
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePersonRequest request)
    {
        var createdResource = await _mediator.Send(request);
        return CreatedAtAction(nameof(Get), new { id = createdResource.Person.Id }, createdResource.Person);
    }

    /// <summary>
    /// Get resource by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet()]
    public IActionResult Get(Guid? id)
    {
        var retrievedResource = _mediator.Send(new GetByIdRequest(id));
        return Ok(retrievedResource);
    }
}