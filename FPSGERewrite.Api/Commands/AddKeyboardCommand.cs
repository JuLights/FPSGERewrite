using FPSGERewrite.Entities.Dtos.Request;
using MediatR;

namespace FPSGERewrite.Api.Commands
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
