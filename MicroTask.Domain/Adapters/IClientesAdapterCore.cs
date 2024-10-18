using MicroTask.Domain.Models;

namespace MicroTask.Domain.Adapters
{
    public interface IClientesAdapterCore
    {
        Task<Clientes> GetByIdAsync(int id);
    }
}
