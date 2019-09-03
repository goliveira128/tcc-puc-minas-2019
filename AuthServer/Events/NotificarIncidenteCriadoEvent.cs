using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Events;

namespace AuthServer.Events
{
    public class NotificarIncidenteCriadoEvent : IntegrationEvent
    {
        public string UserId { get; }


        public NotificarIncidenteCriadoEvent(string userId)
        {
            UserId = userId;
        }
    }
}
