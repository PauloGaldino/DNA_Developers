using AutoMapper;
using DNA.Application.ViewModels;
using DNA.Domain.Commands.Cadastros.Pessoas.Clientes;

namespace DNA.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, RegisterNewClienteCommand>()
                .ConstructUsing(c => new RegisterNewClienteCommand(c.Nome, c.Email, c.DataNascimento));
            CreateMap<ClienteViewModel, UpdateClienteCommand>()
                .ConstructUsing(c => new UpdateClienteCommand(c.Id, c.Nome, c.Email, c.DataNascimento));
        }
    }
}
