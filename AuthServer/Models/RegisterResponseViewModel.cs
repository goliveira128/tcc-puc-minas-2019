using AutentificacaoServer.Infrastructure.Data.Identity;

namespace AuthServer.Models
{
    public class RegisterResponseViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public RegisterResponseViewModel(ApplicationUser user)
        {
            Id = user.Id;
            Name = user.Nome;
            Email = user.Email;
        }
    }
}
