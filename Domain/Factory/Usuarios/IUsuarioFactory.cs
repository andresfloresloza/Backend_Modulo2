using Domain.Model.Usuarios;

namespace Domain.Factory.Usuarios
{
    public interface IUsuarioFactory
    {
        Usuario Crear(string firstName, string lastName, string email, string password);

        String Login(string email, string password);

    }
}
