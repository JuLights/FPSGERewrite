using FPSGERewrite.Entities.DbSet;
using MediatR;

namespace FPSGERewrite.Api.Query
{
    public class GetAllKeyboardQuery : IRequest<IEnumerable<Keyboard>>
    { }
}
