using MicroTask.Domain.Models;

namespace MicroTask.Domain.Adapters
{
    public interface IProdutosAdapterCore
    {
        Task<Produtos> GetByIdAsync(int id);
    }
}
