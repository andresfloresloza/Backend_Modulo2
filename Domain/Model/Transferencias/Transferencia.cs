using SharedKernel.Core;
using SharedKernel.ValueObjects.Transferencias;

namespace Domain.Model.Transferencias
{
    public class Transferencia : AggregateRoot<Guid>
    {
        public Guid CuentaOrigenId { get; private set; }
        public Guid CuentaDestinoId { get; private set; }
        public Guid UsuarioId { get; private set; }
        public SaldoValue Saldo { get; set; }
        public DateTime Fecha { get; private set; }

        public Transferencia() { }

        public Transferencia(Guid cuentaOrigenId, Guid cuentaDestinoId, Guid usuarioId, decimal saldo)
        {
            if (cuentaOrigenId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("La cuenta origen no puede estar vacío.");
            }
            if (cuentaDestinoId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("La cuenta destino no puede estar vacío.");
            }
            if (usuarioId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El usuario no puede estar vacío.");
            }
            Id = Guid.NewGuid();
            CuentaOrigenId = cuentaOrigenId;
            CuentaDestinoId = cuentaDestinoId;
            UsuarioId = usuarioId;
            Saldo = saldo;
            Fecha = DateTime.Now;
        }
    }
}