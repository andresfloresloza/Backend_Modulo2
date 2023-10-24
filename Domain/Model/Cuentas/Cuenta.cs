using SharedKernel.Core;
using SharedKernel.ValueObjects.Cuentas;

namespace Domain.Model.Cuentas
{
    public class Cuenta : AggregateRoot<Guid>
    {
        public Guid UsuarioId { get; private set; }

        public NombreValue Nombre { get; private set; }

        public SaldoValue Saldo { get; private set; }


        public Cuenta() { }

        public Cuenta(Guid usuarioId, string nombre)
        {
            if (usuarioId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El usuario no puede estar vacío.");
            }
            Id = Guid.NewGuid(); 
            Nombre = nombre;
            Saldo = 0;
            UsuarioId = usuarioId;
        }

        public void Ingreso(decimal monto)
        {
            Saldo += monto;
        }

        public void Egreso(decimal monto)
        {
            Saldo -= monto;
        }
    }
}