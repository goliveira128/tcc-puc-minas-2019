using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Events;

namespace NotificacoesSGQ.Events
{
    public class NotificarIncidenteExcluidoAdministradorEvent : IntegrationEvent
    {
        public string UserId { get; }

        public string UserEmail { get; }

        public string Message { get; }

        public NotificarIncidenteExcluidoAdministradorEvent(string userId, string userEmail, string message)
        {
            UserId = userId;
            UserEmail = userEmail;
            Message = message;
        }
    }
}
