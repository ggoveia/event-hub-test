using Microsoft.Azure.EventHubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Infra.Event
{
    public class AzureEventHubHandler : IEventHandler
    {
        EventHubsConnectionStringBuilder _conectionStringBuilder;
        EventHubClient _cliente;

        private const string EhConnectionString = "connectionString";
        private const string EhEntityPath = "entityPath";

        public AzureEventHubHandler()
        {            
            _conectionStringBuilder = new EventHubsConnectionStringBuilder(EhConnectionString) {
                EntityPath = EhEntityPath
            };

            _cliente = EventHubClient.CreateFromConnectionString(_conectionStringBuilder.ToString());

        }

        public async Task Send(List<string> message)
        {
            await _cliente.SendAsync(ReturnEventDataListFrom(message));
        }


        private IEnumerable<EventData> ReturnEventDataListFrom(List<string> messages) => messages.Select(m => new EventData(Encoding.UTF8.GetBytes(m)));

    }
}
