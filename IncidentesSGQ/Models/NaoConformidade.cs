using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentesSGQ.Models
{
    public class NaoConformidade { 
        [Key]
        public string Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
