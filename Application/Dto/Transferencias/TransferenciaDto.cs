
namespace Application.Dto.Transferencias
{
    public class TransferenciaDto
    {
        public Guid Id { get; set; }
        public string CuentaOrigen { get; set; }
        public string CuentaDestino { get; set; }
        public string Usuario { get; set; }
        public decimal Saldo { get; set; }
    }
}
