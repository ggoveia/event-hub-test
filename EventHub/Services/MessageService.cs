using EventHub.Infra.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Services
{
    public class MessageService : IMessageService
    {
        IEventHandler _eventHandler;

        public MessageService(IEventHandler eventHandler)
        {
            _eventHandler = eventHandler;
        }

        public async Task SendAsync(List<string> message) {

           await _eventHandler.Send(message);
        }

    
     }
        
}
