using Domain.Factory.Cuentas;
using Domain.Repository.Cuentas;
using Domain.Repository.Usuarios;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.Commands.Cuentas.CrearCuenta
{
public class CrearCuentaHandler : IRequestHandler<CrearCuentaCommand, Guid>
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICuentaFactory _cuentaFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearCuentaHandler(ICuentaRepository cuentaRepository, IUsuarioRepository usuarioRepository, ICuentaFactory cuentaFactory, IUnitOfWork unitOfWort)
        {
            _cuentaRepository = cuentaRepository;
            _usuarioRepository = usuarioRepository;
            _cuentaFactory = cuentaFactory;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(CrearCuentaCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.FindByIdAsync(request.UsuarioId);

            if (usuario == null)
            {
                throw new BussinessRuleValidationException("Usuario no encontrado");
            }

            var cuenta = _cuentaFactory.Crear(
                request.UsuarioId,
                request.Nombre
                );

            await _cuentaRepository.CreateAsync(cuenta);
            await _unitOfWork.Commit();
            return cuenta.Id;
        }
    }
}
