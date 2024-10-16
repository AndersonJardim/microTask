using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interfaces
{
    public interface IProdutosAdapterCore
    {
        Task<Produtos> GetByIdAsync(int id);
    }
}
