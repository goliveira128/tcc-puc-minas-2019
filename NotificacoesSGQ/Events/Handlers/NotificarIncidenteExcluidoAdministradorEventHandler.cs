using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Interfaces;
using NotificacoesSGQ.Services.Interfaces;


namespace NotificacoesSGQ.Events.Handlers
{
    public class NotificarIncidenteExcluidoAdministradorEventHandler : IIntegrationEventHandler<NotificarIncidenteExcluidoAdministradorEvent>
    {
        private readonly IEmailSender _emailSender;
        public NotificarIncidenteExcluidoAdministradorEventHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public Task Handle(NotificarIncidenteExcluidoAdministradorEvent @event)
        {
            _emailSender.SendEmail("Incidente Excluido!", @event.Message, @event.UserEmail, "envio@miu.com.br", "envio@miu.com.br");

            return Task.CompletedTask;
        }
    }
}
