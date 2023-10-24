using Domain.Model.Movimientos;

namespace Domain.Factory.Movimientos
{
    public interface IMovimientoFactory
    {
        Movimiento Crear(Guid cuentaId, Guid categoriaId, string descripcion, string tipo, decimal saldo);
    }
}
