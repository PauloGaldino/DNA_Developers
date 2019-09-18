using AutoMapper;
using DNA.Application.ViewModels;
using DNA.Application.ViewModels.Cadastro.Producao.Produtos;
using DNA.Domain.Commands.Cadastros.Pessoas.Clientes;
using DNA.Domain.Commands.Cadastros.Producao.Produto;

namespace DNA.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Cliente
            CreateMap<ClienteViewModel, RegisterNewClienteCommand>()
                .ConstructUsing(c => new RegisterNewClienteCommand(c.Nome, c.Email, c.DataNascimento));
            CreateMap<ClienteViewModel, UpdateClienteCommand>()
                .ConstructUsing(c => new UpdateClienteCommand(c.Id, c.Nome, c.Email, c.DataNascimento));

            //Categoria
            CreateMap<CategoriaViewModel, RegisterNewCategoriaCommand>()
               .ConstructUsing(c => new RegisterNewCategoriaCommand(c.Descricao));
            CreateMap<CategoriaViewModel, UpdateCategoriaCommand>()
                .ConstructUsing(c => new UpdateCategoriaCommand(c.Id, c.Descricao));
        }
    }
}
