using Infrastructure.EntityFramwork.ReadModel.Usuarios;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramwork.ReadModel.Cuentas
{
    internal class CuentaReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public UsuarioReadModel Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        public string Nombre { get; set; }
        public decimal Saldo { get; set; }
    }
}
