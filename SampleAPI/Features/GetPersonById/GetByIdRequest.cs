using MediatR;
using SampleAPI.Features.CreatePerson;
using SampleAPI.ToRefactor;

namespace SampleAPI.Features.GetPersonById;

public record GetByIdRequest(Guid? Id): IRequest<Employee[]>;

public class GetByIdRequestHandler : IRequestHandler<GetByIdRequest, Employee[]>
{
    private readonly PersonRepository _personRepository;

    public GetByIdRequestHandler(PersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    
    public async Task<Employee[]> Handle(GetByIdRequest request, CancellationToken cancellationToken)
    {
        if (request.Id is null) 
            return await Task.FromResult(_personRepository.Get());
        var employees = _personRepository.Get(request.Id);
        return await Task.FromResult(employees);
    }
}