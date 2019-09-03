using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentesSGQ.Data.Repository.Base;
using IncidentesSGQ.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentesSGQ.Data.Repository.Incidentes
{
    public class IncidenteRepository : BaseRepository<Incidente>, IIncidenteRepository
    {
        
    }
}
