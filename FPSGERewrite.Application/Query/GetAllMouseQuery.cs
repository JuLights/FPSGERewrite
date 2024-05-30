using FPSGERewrite.Domain.Entities;
using MediatR;

namespace FPSGERewrite.Application.Query
{
    public class GetAllMouseQuery : IRequest<IEnumerable<Mouse>>
    {}
}
