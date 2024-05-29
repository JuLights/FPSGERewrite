using FPSGERewrite.Entities.DbSet;
using FPSGERewrite.Entities.Dtos.Responsne;
using MediatR;

namespace FPSGERewrite.Api.Query
{
    public class GetMouseQuery : IRequest<MouseResponse>
    {
        public Guid Id;
        public GetMouseQuery(Guid id)
        {
            Id = id;
        }
    }
}
