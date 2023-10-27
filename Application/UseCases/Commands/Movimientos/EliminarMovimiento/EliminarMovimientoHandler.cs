using Application.UseCases.Commands.Movimientos.CrearMovimiento;
using Domain.Model.Cuentas;
using Domain.Model.Movimientos;
using Domain.Model.Usuarios;
using Domain.Repository.Cuentas;
using Domain.Repository.Movimientos;
using Domain.Repository.Usuarios;
using MediatR;
using SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Movimientos.EliminarMovimiento
{
    public class EliminarMovimientoHandler : IRequestHandler<EliminarMovimientoCommand, Guid>
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public EliminarMovimientoHandler(IMovimientoRepository movimientoRepository, ICuentaRepository cuentaRepository, IUsuarioRepository usuarioRepository)
        {
            _movimientoRepository = movimientoRepository;
            _cuentaRepository = cuentaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Guid> Handle(EliminarMovimientoCommand request, CancellationToken cancellationToken)
        {
            var movimiento = await _movimientoRepository.FindByIdAsync(request.Id);
            if (movimiento != null)
            {
                var cuenta = await _cuentaRepository.FindByIdAsync(movimiento.CuentaId);
                var usuario = await _usuarioRepository.FindByIdAsync(cuenta.UsuarioId);

                if (movimiento.Tipo == "ingreso")
                {
                    cuenta.Egreso(movimiento.Saldo);
                    await _cuentaRepository.UpdateAsync(cuenta);

                    usuario.EgresoMontoTotal(movimiento.Saldo);
                    await _usuarioRepository.UpdateAsync(usuario);
                }
                else if (movimiento.Tipo == "egreso")
                {
                    cuenta.Ingreso(movimiento.Saldo);
                    await _cuentaRepository.UpdateAsync(cuenta);

                    usuario.IngresoMontoTotal(movimiento.Saldo);
                    await _usuarioRepository.UpdateAsync(usuario);
                }
                await _movimientoRepository.RemoveAsync(movimiento.Id);
            }

            return movimiento.Id;
        }

    }
}
