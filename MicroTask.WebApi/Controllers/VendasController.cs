using Microsoft.AspNetCore.Mvc;
using MicroTask.Domain.Adapters;
using MicroTask.WebApi.Dto;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

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
        public async Task<IActionResult> CadastrarVenda([FromBody]VendasPostDto vendaPost)
        //public async Task<IActionResult> CadastrarVenda(int idCliente, int idProduto) //(VendasPostDto vendaPost)
        {
            var getProduto = await produtosAdapter.GetByIdAsync(vendaPost.IdProduto);
            var getCliente = await httpClient.GetAsync($"https://localhost:7052/api/Clientes/GetById?id={vendaPost.IdCliente}");

            //var getProduto = await produtosAdapter.GetByIdAsync(idProduto);
            //var getCliente = await httpClient.GetAsync($"https://localhost:7052/api/Clientes/GetById?id={idCliente}");

            var clienteDto = JsonConvert.DeserializeObject<ClientesDto>(getCliente.Content.ReadAsStringAsync().Result);

            return Ok(clienteDto);
        }
    }
}
