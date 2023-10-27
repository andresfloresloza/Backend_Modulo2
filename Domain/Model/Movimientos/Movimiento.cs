using SharedKernel.Core;
using SharedKernel.ValueObjects.Transferencias;

namespace Domain.Model.Movimientos
{
    public class Movimiento : AggregateRoot<Guid>
    {
        public Guid CuentaId { get; private set; }
        public Guid CategoriaId { get; private set; }
        public DescripcionValue Descripcion { get; private set; }
        public string Tipo { get; private set; }
        public SaldoValue Saldo { get; set; }
        public DateTime Fecha { get; private set; }

        public Movimiento() { }

        public Movimiento(Guid cuentaId, Guid categoriaId, string descripcion, string tipo, decimal saldo)
        {
            if (cuentaId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("La categoria no puede estar vacío.");
            }
            if (cuentaId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("La cuenta no puede estar vacío.");
            }
            Id = Guid.NewGuid();
            CuentaId = cuentaId;
            CategoriaId = categoriaId;
            Descripcion = descripcion;
            Tipo = tipo;
            Saldo = saldo;
            Fecha = DateTime.Now;
        }

        public void editarMovimiento(Guid cuentaId, Guid categoriaId, string descripcion, string tipo, decimal saldo)
        {
            CuentaId = cuentaId;
            CategoriaId = categoriaId;
            Descripcion = descripcion;
            Tipo = tipo;
            Saldo = saldo;
        }
    }
}