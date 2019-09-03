using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentesSGQ.Models
{
    public class Incidente { 
        [Key]
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string IdUsuario { get; set; }
        public DateTime DataOcorrido { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public string NaoConformidadeId { get; set; }
    }
}
