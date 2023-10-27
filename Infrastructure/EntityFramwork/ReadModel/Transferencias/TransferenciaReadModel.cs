using Infrastructure.EntityFramwork.ReadModel.Cuentas;
using Infrastructure.EntityFramwork.ReadModel.Usuarios;
using System.ComponentModel.DataAnnotations;


namespace Infrastructure.EntityFramwork.ReadModel.Transferencias
{
    internal class TransferenciaReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public CuentaReadModel CuentaOrigen { get; set; }
        public Guid CuentaOrigenId { get; set; }
        public CuentaReadModel CuentaDestino { get; set; }
        public Guid CuentaDestinoId { get; set; }
        public UsuarioReadModel Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
