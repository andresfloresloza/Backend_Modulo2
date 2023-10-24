using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Usuarios.Login
{
    public class LoginResult
    {
        public string Token { get; set; }
        public Guid UsuarioId { get; set; }
    }
}