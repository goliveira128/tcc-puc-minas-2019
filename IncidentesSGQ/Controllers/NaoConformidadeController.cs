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
    public class NaoConformidadeController : ControllerBase
    {
        private readonly INaoConformidadeRepository _naoConformidadeRepository;
        private readonly IEventBus _eventBus;
        public NaoConformidadeController(
            INaoConformidadeRepository naoConformidadeRepository,
            IEventBus eventBus)
        {
            _naoConformidadeRepository = naoConformidadeRepository;
            _eventBus = eventBus;
        }

        [HttpGet("{userId}/{naoConformidadeId}")]
        public async Task<IActionResult> Get(string userId, string naoConformidadeId)
        {
            await Task.Delay(100); // simulate latency
            var model = _naoConformidadeRepository.GetById(naoConformidadeId);
            return Ok(model);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            await Task.Delay(100); // simulate latency
            var model = _naoConformidadeRepository.GetAll();
            return Ok(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] NaoConformidade model, string userId)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            model.Id = null;

        //            _naoConformidadeRepository.ExecuteUnderTransaction(() =>
        //            {
        //                _naoConformidadeRepository.Insert(model);
        //            });

        //            //var eventMessage = new NotificarIncidenteCriadoEvent(userId);

        //            //_eventBus.Publish(eventMessage);

        //            return Ok(true);
        //        }

        //        return BadRequest(ModelState);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(false);
        //    }
        //}

        //[HttpPut]
        //public async Task<IActionResult> Put([FromBody] NaoConformidade model, string userId)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _naoConformidadeRepository.ExecuteUnderTransaction(() =>
        //            {
        //                _naoConformidadeRepository.Update(model);
        //            });

        //            return Ok(true);
        //        }

        //        return BadRequest(ModelState);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(true);
        //    }
        //}

        //[HttpDelete("{userId}/{naoConformidadeId}")]
        //public async Task<IActionResult> Delete(string userId, string naoConformidadeId)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _naoConformidadeRepository.ExecuteUnderTransaction(() =>
        //            {
        //                var model = _naoConformidadeRepository.GetById(naoConformidadeId);
        //                _naoConformidadeRepository.Delete(model);
        //            });

        //            //var eventMessage = new NotificarIncidenteExcluidoEvent(userId);

        //            //_eventBus.Publish(eventMessage);

        //            return Ok(true);
        //        }

        //        return BadRequest(ModelState);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(false);
        //    }
        //}
    }
}

