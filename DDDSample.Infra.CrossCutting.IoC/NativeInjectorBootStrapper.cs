using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using DDDSample.Infra.CrossCutting.Bus;
using DDDSample.Domain.Core.Bus;

using DDDSample.Application.Interfaces;
using DDDSample.Application.Services;

namespace DDDSample.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMediatorHandler, InMemmoryBus>();
            
            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

        }
    }
}
