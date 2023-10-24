using MediatR;

namespace Application.UseCases.Commands.Usuarios.CrearUsuario
{
    public record CrearUsuarioCommand : IRequest<Guid>
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
