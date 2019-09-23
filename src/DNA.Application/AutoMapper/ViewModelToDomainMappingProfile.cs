using AutoMapper;
using DNA.Application.ViewModels;
using DNA.Domain.Commands.Cadastros.Pessoas.Clientes;
using DNA.Domain.Commands.Cadastros.Common.Categorias;
using DNA.Domain.Commands.Cadastros.Common.Fornecedores;
using DNA.Application.ViewModels.Cadastro.Fornecedores;
using DNA.Application.ViewModels.Cadastro.Categorias;

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
               .ConstructUsing(c => new RegisterNewCategoriaCommand(c.Nome, c.Descricao));
            CreateMap<CategoriaViewModel, UpdateCategoriaCommand>()
                .ConstructUsing(c => new UpdateCategoriaCommand(c.Id, c.Nome, c.Descricao));

            //Fornecedores
            CreateMap<FornecedorViewModel, RegisterNewFornecedorCommand>()
               .ConstructUsing(c => new RegisterNewFornecedorCommand(c.NomeCompanhia,c.NomeContato,c.TituloContato,c.Telefone,c.EnderecoEmail,c.Endereco,c.Cidade,c.Estado,c.Pais));
            CreateMap<FornecedorViewModel, UpdateFornecedorCommand>()
                .ConstructUsing(c => new UpdateFornecedorCommand(c.Id, c.NomeCompanhia, c.NomeContato, c.TituloContato, c.Telefone, c.EnderecoEmail, c.Endereco, c.Cidade, c.Estado, c.Pais));
        }
    }
}
