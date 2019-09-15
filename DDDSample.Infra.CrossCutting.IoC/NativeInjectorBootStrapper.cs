using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using DDDSample.Infra.CrossCutting.Bus;
using DDDSample.Domain.Core.Bus;

using DDDSample.Application.Interfaces;
using DDDSample.Application.Services;
using DDDSample.Domain.Core.Notifications;
using DDDSample.Domain.Events;
using DDDSample.Domain.EventHandlers;
using DDDSample.Domain.Commands;
using DDDSample.Domain.CommandHandlers;
using DDDSample.Domain.Interfaces;
using DDDSample.Infra.Data.Repository;
using DDDSample.Infra.Data.UoW;
using DDDSample.Infra.Data.Context;
using DDDSample.Infra.Data.Repository.EventSourcing;
using DDDSample.Domain.Core.Events;
using DDDSample.Infra.Data.EventSourcing;

namespace DDDSample.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Asp .NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemmoryBus>();
            
            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IAdvAppService, AdvAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            services.AddScoped<INotificationHandler<AdvRegisteredEvent>, AdvEventHandler>();
            services.AddScoped<INotificationHandler<AdvUpdatedEvent>, AdvEventHandler>();
            services.AddScoped<INotificationHandler<AdvRemovedEvent>, AdvEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewAdvCommand, bool>, AdvCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateAdvCommand, bool>, AdvCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveAdvCommand, bool>, AdvCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAdvRepository, AdvRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DDDSampleContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

        }
    }
}
