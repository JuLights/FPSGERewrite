using FPSGERewrite.Entities.DbSet;
using MediatR;

namespace FPSGERewrite.Api.Query
{
    public class GetMouseQuery : IRequest<Mouse>
    {
        public Guid Id;
        public GetMouseQuery(Guid id)
        {
            Id = id;
        }
    }
}
