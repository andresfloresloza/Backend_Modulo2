using Domain.Model.Cuentas;

namespace Domain.Factory.Cuentas
{
    public interface ICuentaFactory
    {
        Cuenta Crear(Guid usuarioId, string nombre);
    }
}

