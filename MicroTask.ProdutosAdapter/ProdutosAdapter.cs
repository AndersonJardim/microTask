using AutoMapper;
using MicroTask.Domain.Adapters;
using MicroTask.Domain.Models;
using MicroTask.ProdutosAdapter.Service;

namespace MicroTask.ProdutosAdapter
{
    public class ProdutosAdapter : IProdutosAdapterCore
    {
        private readonly IProdutosAdapter produtosAdapter;
        private readonly IMapper mapper;

        public ProdutosAdapter(IProdutosAdapter produtosAdapter, IMapper mapper)
        {
            this.produtosAdapter = produtosAdapter
                ?? throw new ArgumentNullException(nameof(produtosAdapter));
            this.mapper = mapper;
        }

        public async Task<Produtos> GetByIdAsync(int id)
        {
            try
            {
                var result = await produtosAdapter.GetByIdAsync(id);
                return mapper.Map<Produtos>(result);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
