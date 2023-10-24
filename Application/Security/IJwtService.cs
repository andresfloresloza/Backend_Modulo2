using Domain.Model.Usuarios;

namespace Application.Security
{
    public interface IJwtService
    {
        string GenerateToken(Usuario usuario);

    }
}
