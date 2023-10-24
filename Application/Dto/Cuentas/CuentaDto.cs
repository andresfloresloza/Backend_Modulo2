
namespace Application.Dto.Cuentas
{
    public class CuentaDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string Nombre { get; set; }
        public decimal Saldo { get; set; }
    }
}
