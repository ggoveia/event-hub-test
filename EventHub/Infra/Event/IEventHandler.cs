using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Infra.Event
{
    public interface IEventHandler
    {
        Task Send(List<string> message);
    }
}