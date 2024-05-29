using FPSGERewrite.Entities.DbSet;
using MediatR;

namespace FPSGERewrite.Api.Query
{
    public class GetAllMouseQuery : IRequest<IEnumerable<Mouse>>
    {}
}
