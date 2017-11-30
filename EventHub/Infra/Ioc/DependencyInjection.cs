using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using EventHub.Infra.Event;
using EventHub.Services;

namespace EventHub.Infra.Ioc
{
    public class DependencyInjection
    {
        private readonly IServiceCollection _serviceCollection;

        public DependencyInjection(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public void Resolve() {

            ResolveEventHandler()   
            .ResolveMessageService();
        }
        private DependencyInjection ResolveEventHandler() {

            _serviceCollection.AddScoped<IEventHandler, AzureEventHubHandler>();

            return this;
        }

        private DependencyInjection ResolveMessageService()
        {

            _serviceCollection.AddScoped<IMessageService, MessageService>();

            return this;
        }
        
    }
}
