using Domain.Model.Movimientos;

namespace Domain.Factory.Movimientos
{
    public class MovimientoFactory : IMovimientoFactory
    {
        public Movimiento Crear(Guid CuentaId, Guid CategoriaId, string descripcion, string tipo, decimal saldo)
        {
            return new Movimiento(CuentaId, CategoriaId, descripcion, tipo, saldo);
        }
    }
}
