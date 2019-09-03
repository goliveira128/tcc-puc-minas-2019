using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutentificacaoServer.Infrastructure.Data.Identity;
using Event.Interfaces;
using Microsoft.AspNetCore.Identity;


namespace AuthServer.Events.Handlers
{
    public class NotificarIncidenteCriadoEventHandler : IIntegrationEventHandler<NotificarIncidenteCriadoEvent>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEventBus _eventBus;
        public NotificarIncidenteCriadoEventHandler(UserManager<ApplicationUser> userManager, IEventBus eventBus)
        {
            _userManager = userManager;
            _eventBus = eventBus;
        }
        public Task Handle(NotificarIncidenteCriadoEvent @event)
        {

            var user = _userManager.FindByIdAsync(@event.UserId).Result;

            var adminUsers = _userManager.GetUsersInRoleAsync("administrador").Result;

            foreach (var adminUser in adminUsers)
            {
                var notificarAdministradorEvent = new NotificarIncidenteCriadoAdministradorEvent(adminUser.Id, adminUser.Email,
                    $"Olá {adminUser.Nome}, um novo incidente foi registrado pelo operador {user.Nome} em {DateTime.Now:dd/MM/yyyy}");

                _eventBus.Publish(notificarAdministradorEvent);

            }

            return Task.CompletedTask;
        }
    }
}
