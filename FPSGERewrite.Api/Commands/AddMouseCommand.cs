using FPSGERewrite.Entities.Dtos.Request;
using MediatR;

namespace FPSGERewrite.Api.Commands
{
    public class AddMouseCommand : IRequest<bool>
    {
        public CreateMouseRequest CreateMouseRequest { get;}
        public AddMouseCommand(CreateMouseRequest createMouseRequest)
        {
            CreateMouseRequest = createMouseRequest;
        }
    }
}
