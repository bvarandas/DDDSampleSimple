using System;
using System.Threading;
using System.Threading.Tasks;
using DDDSample.Domain.Commands;
using System.Text;
using MediatR;
using DDDSample.Domain.Interfaces;
using DDDSample.Domain.Core.Bus;
using DDDSample.Domain.Core.Notifications;
using DDDSample.Domain.Models;
using DDDSample.Domain.Events;

namespace DDDSample.Domain.CommandHandlers
{
    public class AdvCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewAdvCommand, bool>,
        IRequestHandler<UpdateAdvCommand, bool>,
        IRequestHandler<RemoveAdvCommand, bool>

    {
        private readonly IAdvRepository _advRepository;
        private readonly IMediatorHandler Bus;

        public AdvCommandHandler(IAdvRepository advRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _advRepository = advRepository;
            Bus = bus;
        }

        public void Dispose()
        {
            _advRepository.Dispose();
        }

        public Task<bool> Handle(RegisterNewAdvCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var adv = new Adv(message.Marca, message.Modelo, message.Versao, message.Ano, message.Quilometragem, message.Observacao);
            
            _advRepository.Add(adv);

            if (Commit())
            {
                Bus.RaiseEvent(new AdvRegisteredEvent(message.ID, message.Marca, message.Modelo, message.Versao, message.Ano ,message.Quilometragem, message.Observacao));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateAdvCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var adv = new Adv(message.ID, message.Marca, message.Modelo, message.Versao, message.Ano, message.Quilometragem, message.Observacao);
            
            _advRepository.Update(adv);

            if (Commit())
            {
                Bus.RaiseEvent(new AdvUpdatedEvent(message.ID, message.Marca, message.Modelo, message.Versao, message.Ano, message.Quilometragem, message.Observacao));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveAdvCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _advRepository.Remove(message.ID);

            if (Commit())
            {
                Bus.RaiseEvent(new AdvRemovedEvent(message.ID));
            }

            return Task.FromResult(true);
        }
    }
}
