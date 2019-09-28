using AutoMapper;
using DNA.Application.ViewModels;
using DNA.Domain.Models.Cadastros.Pessoas;
using DNA.Domain.Models.Cadastros.Common.Categorias;
using DNA.Domain.Models.Cadastros.Common.Fornecedores;
using DNA.Application.ViewModels.Cadastro.Common.Fornecedores;
using DNA.Application.ViewModels.Cadastro.Common.Categorias;
using DNA.Domain.Models.Cadastros.Common.Expedidores;
using DNA.Application.ViewModels.Cadastro.Common.Expedidores;

namespace DNA.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Fornecedor, FornecedorViewModel>();
            CreateMap<Expedidor, ExpedidorViewModel>();
            CreateMap<Empregado, ExpedidorViewModel>();
        }
    }
}
