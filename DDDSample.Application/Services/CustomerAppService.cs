using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DDDSample.Application.EventSourcedNormalizers;
using DDDSample.Application.Interfaces;
using DDDSample.Application.ViewModels;
using DDDSample.Domain.Core.Bus;
using DDDSample.Domain.Interfaces;
using DDDSample.Infra.Data;
using DDDSample.Infra.Data.Repository.EventSourcing;
using System.Linq;
using AutoMapper.QueryableExtensions;
using DDDSample.Domain.Commands;

namespace DDDSample.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public CustomerAppService(IMapper mapper, 
            ICustomerRepository customerRepository, 
            IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return _customerRepository.GetAll().ProjectTo<CustomerViewModel>(_mapper.ConfigurationProvider);
        }

        public IList<CustomerHistoryData> GetAllHistory(int id)
        {
            return CustomerHistory.ToJavaScriptCustomerHistory(_eventStoreRepository.All(id));
        }

        public CustomerViewModel GetById(int id)
        {
            return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
        }

        public void Register(CustomerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            Bus.SendCommand(removeCommand);

        }

        public void Update(CustomerViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
