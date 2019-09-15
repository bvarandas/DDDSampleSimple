using System.Threading;
using System.Threading.Tasks;
using DDDSample.Domain.Events;
using MediatR;

namespace DDDSample.Domain.EventHandlers
{
    public class AdvEventHandler :
        INotificationHandler<AdvRegisteredEvent>,
        INotificationHandler<AdvUpdatedEvent>,
        INotificationHandler<AdvRemovedEvent>
    {
        public Task Handle(AdvRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification

            return Task.CompletedTask;
        }

        public Task Handle(AdvUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification

            return Task.CompletedTask;
        }

        public Task Handle(AdvRemovedEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification

            return Task.CompletedTask;
        }
    }
}
