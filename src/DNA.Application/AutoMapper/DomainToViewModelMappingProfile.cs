using AutoMapper;
using DNA.Application.ViewModels;
using DNA.Domain.Models.Cadastros.Pessoas;
using DNA.Domain.Models.Cadastros.Common.Categorias;
using DNA.Domain.Models.Cadastros.Common.Fornecedores;
using DNA.Application.ViewModels.Cadastro.Fornecedores;
using DNA.Application.ViewModels.Cadastro.Categorias;

namespace DNA.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Fornecedor, FornecedorViewModel>();
        }
    }
}
