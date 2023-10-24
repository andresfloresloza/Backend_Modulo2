using Domain.Model.Usuarios;

namespace Domain.Factory.Usuarios
{
    public class UsuarioFactory : IUsuarioFactory
    {
        public Usuario Crear(string firstName, string lastName, string email, string password)
        {
            return new Usuario(firstName, lastName, email, password);
        }

        public String Login(string email, string password)
        {
            return "Login" + email;
        }
    }
}
    