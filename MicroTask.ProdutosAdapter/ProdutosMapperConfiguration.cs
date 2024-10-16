using AutoMapper;
using MicroTask.Domain.Models;
using MicroTask.ProdutosAdapter.Service;

namespace MicroTask.ProdutosAdapter
{
    public class ProdutosMapperConfiguration : Profile
    {
        public ProdutosMapperConfiguration()
        {
            CreateMap<ProdutosGetResult, Produtos>();
        }
    }
}
