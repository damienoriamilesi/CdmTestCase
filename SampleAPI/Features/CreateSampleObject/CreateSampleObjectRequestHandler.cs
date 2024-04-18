using MediatR;
using SampleAPI.ToRefactor;
using static SampleAPI.Controllers.SampleController;

namespace SampleAPI.Features.CreateSampleObject
{
    public class CreatePersonRequestHandler : IRequestHandler<CreatePersonRequest, CreatePersonResponse>
    {
        public Task<CreatePersonResponse> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Employee> retrievedPersons = new MessyClass().Get();

            var response = new CreatePersonResponse(retrievedPersons.First());

            return Task.FromResult(response);
        }
    }

    public record CreatePersonRequest(PersonTypes SampleObjectType) : IRequest<CreatePersonResponse>;
    public record CreatePersonResponse(Person Person);


    /// <inheritdoc />
    public class Employee : Person
    {
        public string ProfileType { get; set; }
        public float Amount { get; set; }
        public DateTime BirthdayDate { get; set; }
    }
}
