using DDDSample.Application.EventSourcedNormalizers;
using DDDSample.Application.ViewModels;
using System;
using System.Collections.Generic;


namespace DDDSample.Application.Interfaces
{
    public interface IAdvAppService : IDisposable
    {
        void Register(AdvViewModel advViewModel);
        IEnumerable<AdvViewModel> GetAll();
        AdvViewModel GetById(int id);
        void Update(AdvViewModel advViewModel);
        void Remove(int id);
        IList<AdvHistoryData> GetAllHistory(int id);
    }
}
