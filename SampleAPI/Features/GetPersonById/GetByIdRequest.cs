using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAPI.Features.CreatePerson;

namespace SampleAPI.Features.GetPersonById;

public record GetByIdRequest(Guid? id): IRequest<Employee[]>;

public class GetByIdRequestHandler : IRequestHandler<GetByIdRequest, Employee[]>
{
    public PersonDbContext db { get; set; }
    
    public async Task<Employee[]> Handle(GetByIdRequest request, CancellationToken cancellationToken)
    {
        db ??= new PersonDbContext(new DbContextOptions<DbContext>());
        if (request.id is null) return db.Set<Employee>().ToArray();
        return db.Set<Employee>().Where(x=> x.Id == request.id).ToArray();
    }
}