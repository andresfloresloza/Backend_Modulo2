using Domain.Model.Transferencias;

namespace Domain.Factory.Transferencias
{
    public class TransferenciaFactory : ITransferenciaFactory
    {
        public Transferencia Crear(Guid cuentaOrigenId, Guid cuentaDestinoId, Guid usuarioId, decimal saldo)
        {
            return new Transferencia(cuentaOrigenId, cuentaDestinoId, usuarioId, saldo);
        }
    }
}
