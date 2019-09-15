using AutoMapper;
using DDDSample.Application.ViewModels;
using DDDSample.Domain.Commands;

namespace DDDSample.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AdvViewModel, RegisterNewAdvCommand>()
                .ConstructUsing(c => new RegisterNewAdvCommand(c.Marca, c.Modelo, c.Versao, c.Ano, c.Quilometragem, c.Observacao));
            CreateMap<AdvViewModel, UpdateAdvCommand>()
                .ConstructUsing(c => new UpdateAdvCommand(c.ID, c.Marca, c.Modelo, c.Versao, c.Ano, c.Quilometragem, c.Observacao));
        }
    }
}
