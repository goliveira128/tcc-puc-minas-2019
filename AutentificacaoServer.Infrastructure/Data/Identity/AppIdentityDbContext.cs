using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutentificacaoServer.Infrastructure.Data.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            const string ADMIN_ID = "1df9a767-8671-4494-9814-d5bdf3a8ee97";
            const string ADMIN_ROLE_ID = "d0941667-5016-4848-845a-4e08104c2e0b";


            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = Constants.Roles.Operador, NormalizedName = Constants.Roles.Operador.ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole {Id  = ADMIN_ROLE_ID, Name = Constants.Roles.Administrador, NormalizedName = Constants.Roles.Administrador.ToUpper() });

            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                Nome = "Administrador",
                SobreNome = "Teste",
                Email = "guilherme.dg@outlook.com",
                NormalizedEmail = "GUILHERME.DG@OUTLOOK.COM",
                Cidade = "São Paulo",
                Cep = "03589001",
                Pais = "Brasil",
                Estado = "SP",
                EmailConfirmed = true,
                Endereco = "Av Walmdemar Tietz",
                SecurityStamp = string.Empty,
                UserName = "guilherme.dg@outlook.com",
                NormalizedUserName = "GUILHERME.DG@OUTLOOK.COM",
                PasswordHash = hasher.HashPassword(null, "Senha.01"),

            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData( new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });

        }
    }
}
