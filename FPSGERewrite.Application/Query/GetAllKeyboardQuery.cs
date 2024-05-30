using FPSGERewrite.Domain.Entities;
using MediatR;

namespace FPSGERewrite.Application.Query
{
    public class GetAllKeyboardQuery : IRequest<IEnumerable<Keyboard>>
    { }
}
