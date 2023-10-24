
namespace Application.Dto.Movimientos
{
    public class MovimientoDto
    {
        public Guid Id { get; set; }
        public Guid CuentaId { get; set; }
        public Guid CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public decimal Saldo { get; set; }
    }
}
