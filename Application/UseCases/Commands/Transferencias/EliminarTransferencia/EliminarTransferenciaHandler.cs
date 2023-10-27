using Application.UseCases.Commands.Movimientos.EliminarMovimiento;
using Domain.Model.Cuentas;
using Domain.Model.Movimientos;
using Domain.Repository.Cuentas;
using Domain.Repository.Movimientos;
using Domain.Repository.Transferencias;
using Domain.Repository.Usuarios;
using MediatR;

namespace Application.UseCases.Commands.Transferencias.EliminarTransferencia
{
     public class EliminarTransferenciaHandler : IRequestHandler<EliminarTransferenciaCommand, Guid>
    {
        private readonly ITransferenciaRepository _transferenciaRepository;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public EliminarTransferenciaHandler(ITransferenciaRepository transferenciaRepository, ICuentaRepository cuentaRepository, IUsuarioRepository usuarioRepository)
        {
            _transferenciaRepository = transferenciaRepository;
            _cuentaRepository = cuentaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Guid> Handle(EliminarTransferenciaCommand request, CancellationToken cancellationToken)
        {
            var transferencia = await _transferenciaRepository.FindByIdAsync(request.Id);
            if (transferencia != null)
            {
                var cuentaOrigen = await _cuentaRepository.FindByIdAsync(transferencia.CuentaOrigenId);
                var cuentaDestino = await _cuentaRepository.FindByIdAsync(transferencia.CuentaDestinoId);

                cuentaOrigen.Ingreso(transferencia.Saldo);
                await _cuentaRepository.UpdateAsync(cuentaOrigen);

                cuentaDestino.Egreso(transferencia.Saldo);
                await _cuentaRepository.UpdateAsync(cuentaDestino);

            }
            await _transferenciaRepository.RemoveAsync(transferencia.Id);
            return transferencia.Id;

        }
    }
}
