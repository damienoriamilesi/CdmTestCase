using MediatR;
using SampleAPI.ToRefactor;
using static SampleAPI.Controllers.SampleController;

namespace SampleAPI.Features.CreateSampleObject
{
    public class CreateSampleObjectRequestHandler : IRequestHandler<CreateSampleObjectRequest, CreateSampleObjectResponse>
    {
        public Task<CreateSampleObjectResponse> Handle(CreateSampleObjectRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateSampleObjectResponse(new Foo
            {
                Id = 42, 
                Amount = 123456,
                BirthdayDate = new DateTime(2014,04,10),
                Name = "CDM",
                ProfileType = "type1"
            });

            return Task.FromResult(response);
        }
    }

    public record CreateSampleObjectRequest(SampleObjectTypes SampleObjectType) : IRequest<CreateSampleObjectResponse>;
    public record CreateSampleObjectResponse(Foo foo);
}
