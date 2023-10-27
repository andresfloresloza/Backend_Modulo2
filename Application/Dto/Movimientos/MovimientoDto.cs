
namespace Application.Dto.Movimientos
{
    public class MovimientoDto
    {
        public Guid Id { get; set; }
        public string Cuenta { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public decimal Saldo { get; set; }
    }
}
