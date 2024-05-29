using FPSGERewrite.Entities.DbSet;
using MediatR;

namespace FPSGERewrite.Api.Query
{
    public class GetKeyboardQuery : IRequest<Keyboard>
    {
        public Guid Id { get; set; }
        public GetKeyboardQuery(Guid id)
        {

            Id = id;

        }
    }
}
