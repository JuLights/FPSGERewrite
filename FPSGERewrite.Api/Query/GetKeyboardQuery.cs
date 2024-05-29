using FPSGERewrite.Entities.DbSet;
using FPSGERewrite.Entities.Dtos.Responsne;
using MediatR;

namespace FPSGERewrite.Api.Query
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
