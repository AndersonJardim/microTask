using Refit;

namespace MicroTask.ProdutosAdapter.Service
{
    public interface IProdutosAdapter
    {
        [Get("/api/Produtos/GetById")]
        Task<ProdutosGetResult> GetByIdAsync([Query] int id);
    }
}
