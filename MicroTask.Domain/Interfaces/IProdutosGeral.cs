using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interfaces
{
    public interface IProdutosGeral
    {
        Task<Produtos> GetByIdAsync(int id);
    }
}
