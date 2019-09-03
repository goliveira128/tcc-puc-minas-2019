using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace AutentificacaoServer.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Cep { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string SobreNome { get; set; }
        
    }
}
