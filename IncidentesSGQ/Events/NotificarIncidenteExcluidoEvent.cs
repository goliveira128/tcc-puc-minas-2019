using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Events;

namespace IncidentesSGQ.Events
{
    public class NotificarIncidenteExcluidoEvent : IntegrationEvent
    {
        public string UserId { get; }
        

        public NotificarIncidenteExcluidoEvent(string userId)
        {
            UserId = userId;
        }
    }
}
