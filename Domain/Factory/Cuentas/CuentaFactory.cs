using Domain.Model.Cuentas;

namespace Domain.Factory.Cuentas
{
    public class CuentaFactory : ICuentaFactory
    {
        public Cuenta Crear(Guid UsuarioId, string nombre)
        {
            return new Cuenta(UsuarioId, nombre);
        }

    }
}
