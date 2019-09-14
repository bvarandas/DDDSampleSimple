﻿using DDDSample.Application.EventSourcedNormalizers;
using DDDSample.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
        IList<CustomerHistoryData> GetAllHistory(Guid id);

    }
}