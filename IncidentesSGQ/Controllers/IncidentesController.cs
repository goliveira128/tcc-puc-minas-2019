using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Interfaces;
using IncidentesSGQ.Data.Repository.Incidentes;
using IncidentesSGQ.Events;
using IncidentesSGQ.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IncidentesSGQ.Controllers
{
    [Authorize(Policy = "OperadorAdministrador")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IncidentesController : ControllerBase
    {
        private readonly IIncidenteRepository _incidenteRepository;
        private readonly IEventBus _eventBus;
        public IncidentesController(
            IIncidenteRepository incidenteRepository,
            IEventBus eventBus)
        {
            _incidenteRepository = incidenteRepository;
            _eventBus = eventBus;
        }

        [HttpGet("{userId}/{incidenteId}")]
        public async Task<IActionResult> Get(string userId, string incidenteId)
        {
            await Task.Delay(100); // simulate latency
            var incidente = _incidenteRepository.GetById(incidenteId);
            return Ok(incidente);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            await Task.Delay(100); // simulate latency
            var incidentes = _incidenteRepository.GetAll();
            return Ok(incidentes);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Incidente incidente, string userId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    incidente.Id = null;

                    _incidenteRepository.ExecuteUnderTransaction(() =>
                    {
                        _incidenteRepository.Insert(incidente);
                    });

                    var eventMessage = new NotificarIncidenteCriadoEvent(userId);

                    _eventBus.Publish(eventMessage);

                    return Ok(true);
                }

                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(false);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Incidente incidente, string userId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _incidenteRepository.ExecuteUnderTransaction(() =>
                    {
                        _incidenteRepository.Update(incidente);
                    });

                    return Ok(true);
                }

                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(true);
            }
        }

        [HttpDelete("{userId}/{incidenteId}")]
        public async Task<IActionResult> Delete(string userId, string incidenteId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _incidenteRepository.ExecuteUnderTransaction(() =>
                    {
                        var incidente = _incidenteRepository.GetById(incidenteId);

                        _incidenteRepository.Delete(incidente);
                    });

                    var eventMessage = new NotificarIncidenteExcluidoEvent(userId);

                    _eventBus.Publish(eventMessage);

                    return Ok(true);
                }

                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return BadRequest(false);
            }
        }
    }
}
