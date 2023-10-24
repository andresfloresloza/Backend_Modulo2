using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramwork.ReadModel.Usuarios
{
    internal class UsuarioReadModel
    {
        [Key]
        public Guid UsuarioId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public decimal MontoTotal { get; set; }

    }
}
