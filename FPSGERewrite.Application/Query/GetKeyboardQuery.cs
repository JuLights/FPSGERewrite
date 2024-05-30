using FPSGERewrite.Application.Dtos.Response;
using MediatR;

namespace FPSGERewrite.Application.Query
{
    public class GetKeyboardQuery : IRequest<KeyboardResponse>
    {
        public Guid Id { get; set; }
        public GetKeyboardQuery(Guid id)
        {

            Id = id;

        }
    }
}
