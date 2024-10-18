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
        private readonly HttpClient httpClient;

        public VendasController(ILoggerFactory loggerFactory, 
            IProdutosAdapterCore produtosAdapter, 
            HttpClient httpClientBuilder)
        {
            logger = loggerFactory.CreateLogger<VendasController>()
                ?? throw new ArgumentNullException(nameof(loggerFactory));

            this.produtosAdapter = produtosAdapter
                ?? throw new ArgumentNullException(nameof(produtosAdapter));

            this.httpClient = httpClientBuilder
                ?? throw new ArgumentNullException(nameof(httpClientBuilder));
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarVenda(VendasPostDto vendaPost)
        {
            var getProduto = await produtosAdapter.GetByIdAsync(vendaPost.IdProduto);
            var getCliente = await httpClient.GetAsync($"https://localhost:7052/api/Clientes/GetById?id={vendaPost.IdCliente}");
            return Ok((getProduto, getCliente));
        }
    }
}
