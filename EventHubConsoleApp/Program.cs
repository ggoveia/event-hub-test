using EventHub.Infra.Ioc;
using EventHub.Process;
using EventHub.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EventHubConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Dependency Injection
            var serviceCollectionProvider = new ServiceCollection();            
            var container = new DependencyInjection(serviceCollectionProvider);
            container.Resolve();
            var messageService = serviceCollectionProvider.BuildServiceProvider().GetService<IMessageService>();

            PublishingProcess.With(messageService).SendMessages();
        }
        
    }
}
