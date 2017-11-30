using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Services
{
    public interface IMessageService
    {
        Task SendAsync(List<string> message);
    }
}