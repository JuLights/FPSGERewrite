using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSGERewrite.Infrastructure.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IMouseRepository MouseRepository { get; }
        IKeyboardRepository KeyboardRepository { get; }

        Task<bool> CompleteAsync();
    }
}
