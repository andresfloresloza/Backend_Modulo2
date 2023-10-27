using Domain.Factory.Usuarios;
using Domain.Model.Usuarios;
using Domain.Repository.Usuarios;
using MediatR;
using SharedKernel.Core;
using System.Security.Cryptography;
using System.Text;

namespace Application.UseCases.Commands.Usuarios.CrearUsuario
{
    public class CrearUsuarioHandler : IRequestHandler<CrearUsuarioCommand, Guid>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioFactory _usuarioFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearUsuarioHandler(IUsuarioRepository usuarioRepository, IUsuarioFactory usuarioFactory, IUnitOfWork unitOfWort)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioFactory = usuarioFactory;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = GetUsuario(request);
            usuario.AñadirPorDefecto(usuario.Id);

            await _usuarioRepository.CreateAsync(usuario);
            await _unitOfWork.Commit();
            return usuario.Id;
        }

        private Usuario GetUsuario(CrearUsuarioCommand request)
        {
            var passwordHash = HashPasswordSHA256(request.Password);

            return _usuarioFactory.Crear(request.FirstName, request.LastName, request.Email, passwordHash);
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
