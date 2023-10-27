
using Domain.Factory.Movimientos;
using Domain.Factory.Transferencias;
using Domain.Model.Categorias;
using Domain.Model.Cuentas;
using Domain.Model.Movimientos;
using Domain.Repository.Categorias;
using Domain.Repository.Cuentas;
using Domain.Repository.Movimientos;
using Domain.Repository.Transferencias;
using Domain.Repository.Usuarios;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.Commands.Transferencias.CrearTransferencia
{
    public class CrearTransferenciaHandler : IRequestHandler<CrearTransferenciaCommand, Guid>
    {
        private readonly ITransferenciaRepository _transferenciaRepository;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITransferenciaFactory _transferenciaFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearTransferenciaHandler(ITransferenciaRepository transferenciaRepository, ICuentaRepository cuentaRepository, IUsuarioRepository usuarioRepository, ITransferenciaFactory transferenciaFactory, IUnitOfWork unitOfWort)
        {
            _transferenciaRepository = transferenciaRepository;
            _cuentaRepository = cuentaRepository;
            _usuarioRepository = usuarioRepository;
            _transferenciaFactory = transferenciaFactory;
            _unitOfWork = unitOfWort;
        }

        public async Task<Guid> Handle(CrearTransferenciaCommand request, CancellationToken cancellationToken)
        {
            var cuentaOrigen = await _cuentaRepository.FindByIdAsync(request.CuentaOrigenId);
            var cuentaDestino = await _cuentaRepository.FindByIdAsync(request.CuentaDestinoId);
            var usuario = await _usuarioRepository.FindByIdAsync(request.UsuarioId);

            if (cuentaOrigen == null)
            {
                throw new BussinessRuleValidationException("Cuenta Origen no encontrada");
            }
            if (cuentaDestino == null)
            {
                throw new BussinessRuleValidationException("Cuenta Destino no encontrada");
            }
            if (usuario == null)
            {
                throw new BussinessRuleValidationException("Usuario no encontrado");
            }

            var transferencia = _transferenciaFactory.Crear(
                    request.CuentaOrigenId,
                    request.CuentaDestinoId,
                    request.UsuarioId,
                    request.Saldo
                );

            cuentaOrigen.Egreso(request.Saldo);
            cuentaDestino.Ingreso(request.Saldo);

            await _transferenciaRepository.CreateAsync(transferencia);
            await _cuentaRepository.UpdateAsync(cuentaOrigen);
            await _cuentaRepository.UpdateAsync(cuentaDestino);
            await _unitOfWork.Commit();
            return transferencia.Id;
        }
    }
}
