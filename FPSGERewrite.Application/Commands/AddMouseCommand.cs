using FPSGERewrite.Application.Dtos.Request;
using MediatR;

namespace FPSGERewrite.Application.Commands
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
