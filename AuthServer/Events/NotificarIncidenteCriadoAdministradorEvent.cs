using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Events;

namespace AuthServer.Events
{
    public class NotificarIncidenteCriadoAdministradorEvent : IntegrationEvent
    {
        public string UserId { get; }

        public string UserEmail { get; }

        public string Message { get; }

        public NotificarIncidenteCriadoAdministradorEvent(string userId, string userEmail, string message)
        {
            UserId = userId;
            UserEmail = userEmail;
            Message = message;
        }
    }
}
