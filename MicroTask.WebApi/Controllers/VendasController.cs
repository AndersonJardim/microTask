using Microsoft.AspNetCore.Mvc;
using MicroTask.Domain.Adapters;
using MicroTask.WebApi.Dto;

namespace MicroTask.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IProdutosAdapterCore produtosAdapter;

        public VendasController(ILoggerFactory loggerFactory, IProdutosAdapterCore produtosAdapter)
        {
            logger = loggerFactory.CreateLogger<VendasController>()
                ?? throw new ArgumentNullException(nameof(loggerFactory));
            this.produtosAdapter = produtosAdapter;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarVenda(VendasPostDto vendaPost)
        {
            var testePost = await produtosAdapter.GetByIdAsync(vendaPost.IdProduto);
            return Ok(testePost);
        }
    }
}
