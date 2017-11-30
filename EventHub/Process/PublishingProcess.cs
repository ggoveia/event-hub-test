using EventHub.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventHub.Process
{
    public class PublishingProcess
    {
        IMessageService _messageService;

        public List<string> Messages { get; private set; }

        private PublishingProcess(IMessageService messageService) {

            _messageService = messageService;
        }

        public static PublishingProcess With(IMessageService messageService) {

           return new PublishingProcess(messageService);

        }

        public PublishingProcess These(List<string> message) {

            Messages = message;
            return this;
        }

        public async Task SendMessages() {

            await _messageService.SendAsync(Messages);
        }
    }
}
