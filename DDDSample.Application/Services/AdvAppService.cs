using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DDDSample.Application.EventSourcedNormalizers;
using DDDSample.Application.Interfaces;
using DDDSample.Application.ViewModels;
using DDDSample.Domain.Commands;
using DDDSample.Domain.Core.Bus;
using DDDSample.Domain.Interfaces;
using DDDSample.Infra.Data.Repository.EventSourcing;

namespace DDDSample.Application.Services
{
    public class AdvAppService : IAdvAppService
    {
        private readonly IMapper _mapper;
        private readonly IAdvRepository _advRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public AdvAppService(IMapper mapper, IAdvRepository advRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _advRepository = advRepository;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;
        }

        public IEnumerable<AdvViewModel> GetAll()
        {
            return _advRepository.GetAll().ProjectTo<AdvViewModel>(_mapper.ConfigurationProvider);
        }

        public AdvViewModel GetById(int id)
        {
            return _mapper.Map<AdvViewModel>(_advRepository.GetByIdInt(id));
        }

        public void Register(AdvViewModel advViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewAdvCommand>(advViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(AdvViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateAdvCommand>(customerViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveAdvCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<AdvHistoryData> GetAllHistory(int id)
        {
            return AdvHistory.ToJavaScriptAdvHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
