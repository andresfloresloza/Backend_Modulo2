using Application.Security;
using Domain.Model.Usuarios;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace Application.UseCases.Commands.Usuarios.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly AuthenticationSecurity _authenticationSecurity;
        private readonly IJwtService _jwtService;

        public LoginHandler(AuthenticationSecurity authenticationSecurity, IJwtService jwtService)
        {
            _authenticationSecurity = authenticationSecurity;
            _jwtService = jwtService;
        }

        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = HashPasswordSHA256(request.Password);

            var authenticatedUsuario = _authenticationSecurity.AuthenticateUsuario(request.Email, passwordHash);

            if (authenticatedUsuario != null)
            {
                string token = _jwtService.GenerateToken(authenticatedUsuario.Result);

                var loginResult = new LoginResult
                {
                    Token = token,
                    UsuarioId = authenticatedUsuario.Result.Id
                };

                return loginResult;
            }

            throw new Exception("Credenciales inválidas");
        }

        private string HashPasswordSHA256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                string hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}