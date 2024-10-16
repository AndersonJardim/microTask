using Refit;

namespace MicroTask.ProdutosAdapter.Service
{
    public interface IProdutosAdapter
    {
        [Get("api/Produtos/GetById/{id}")]
        Task<ProdutosGetResult> GetByIdAsync(int id);
    }
}
