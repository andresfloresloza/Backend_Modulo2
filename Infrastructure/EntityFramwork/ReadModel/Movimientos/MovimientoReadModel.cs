using Infrastructure.EntityFramwork.ReadModel.Categorias;
using Infrastructure.EntityFramwork.ReadModel.Cuentas;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramwork.ReadModel.Movimientos
{
    internal class MovimientoReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public CuentaReadModel Cuenta { get; set; }
        public Guid CuentaId { get; set; }
        public CategoriaReadModel Categoria { get; set; }
        public Guid CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
