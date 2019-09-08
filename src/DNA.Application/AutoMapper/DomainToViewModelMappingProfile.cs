using AutoMapper;
using DNA.Application.ViewModels;
using DNA.Domain.Models.Cadastros.Pessoas;

namespace DNA.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}
