using Domain.Repository.Usuarios;

namespace Domain.Model.Usuarios
{
    public class AuthenticationSecurity
    {
        private readonly IUsuarioRepository _usuarioRepository; 

        public AuthenticationSecurity(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> AuthenticateUsuario(string email, string password)
        {
            Usuario usuario = await _usuarioRepository.GetAsync(email);

            if (usuario == null)
            {
                return null;
            }

            if (usuario.Password == password)
            {
                return usuario;
            }
            return null;
        }
    }

}
