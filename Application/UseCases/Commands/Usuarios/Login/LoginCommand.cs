using MediatR;

namespace Application.UseCases.Commands.Usuarios.Login
{
    public class LoginCommand : IRequest<LoginResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}