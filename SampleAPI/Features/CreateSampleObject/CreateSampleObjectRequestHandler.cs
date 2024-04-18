using MediatR;
using SampleAPI.ToRefactor;
using static SampleAPI.Controllers.SampleController;

namespace SampleAPI.Features.CreateSampleObject
{
    public class CreateSampleObjectRequestHandler : IRequestHandler<CreateSampleObjectRequest, CreateSampleObjectResponse>
    {
        public Task<CreateSampleObjectResponse> Handle(CreateSampleObjectRequest request, CancellationToken cancellationToken)
        {
            var repo = new MessyClass().Get();

            var response = new CreateSampleObjectResponse(repo.FirstOrDefault());

            return Task.FromResult(response);
        }
    }

    public record CreateSampleObjectRequest(SampleObjectTypes SampleObjectType) : IRequest<CreateSampleObjectResponse>;
    public record CreateSampleObjectResponse(Foo foo);
}
