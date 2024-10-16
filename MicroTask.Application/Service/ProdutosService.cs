using MicroTask.Domain.Interfaces;
using MicroTask.Domain.Models;

namespace MicroTask.Application.Service
{
    public class ProdutosService : IProdutosAdapterCore
    {
        private readonly IProdutosAdapterCore produtosAdapter;

        public ProdutosService(IProdutosAdapterCore produtosAdapter)
        {
            this.produtosAdapter = produtosAdapter
                ?? throw new ArgumentNullException(nameof(produtosAdapter));
        }

        public async Task<Produtos> GetByIdAsync(int id)
        {
            return await produtosAdapter.GetByIdAsync(id);
        }
    }
}
