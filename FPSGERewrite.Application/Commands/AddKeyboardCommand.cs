using FPSGERewrite.Application.Dtos.Request;
using MediatR;

namespace FPSGERewrite.Application.Commands
{
    public class AddKeyboardCommand : IRequest<bool>
    {
        public CreateKeyboardRequest CreateKeyboardRequest { get; }
        public AddKeyboardCommand(CreateKeyboardRequest createKeyboardRequest)
        {
            CreateKeyboardRequest = createKeyboardRequest;
        }
    }
}
