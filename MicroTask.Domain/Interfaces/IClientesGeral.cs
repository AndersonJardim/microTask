using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interfaces
{
    public interface IClietesGeral
    {
        Task<Clientes> GetByIdAsync(int id);
    }
}
