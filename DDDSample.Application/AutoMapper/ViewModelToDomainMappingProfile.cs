using AutoMapper;
using DDDSample.Application.ViewModels;
using DDDSample.Domain.Commands;

namespace DDDSample.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));

            CreateMap<CustomerViewModel, UpdateCustomerCommand>().
                ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Name, c.BirthDate));
        }
    }
}
