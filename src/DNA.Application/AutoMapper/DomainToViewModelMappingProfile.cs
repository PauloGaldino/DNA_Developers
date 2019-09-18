using AutoMapper;
using DNA.Application.ViewModels;
using DNA.Application.ViewModels.Cadastro.Producao.Produtos;
using DNA.Domain.Models.Cadastros.Pessoas;
using DNA.Domain.Models.Cadastros.Producao;

namespace DNA.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
