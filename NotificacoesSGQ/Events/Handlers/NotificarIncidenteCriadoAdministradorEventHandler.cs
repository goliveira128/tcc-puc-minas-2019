using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Interfaces;
using NotificacoesSGQ.Services.Interfaces;


namespace NotificacoesSGQ.Events.Handlers
{
    public class NotificarIncidenteCriadoAdministradorEventHandler : IIntegrationEventHandler<NotificarIncidenteCriadoAdministradorEvent>
    {
        private readonly IEmailSender _emailSender;
        public NotificarIncidenteCriadoAdministradorEventHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public Task Handle(NotificarIncidenteCriadoAdministradorEvent @event)
        {
            _emailSender.SendEmail("Incidente Registrado!", @event.Message, @event.UserEmail, "envio@miu.com.br", "envio@miu.com.br");

            return Task.CompletedTask;
        }
    }
}
