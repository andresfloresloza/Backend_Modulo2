using Application.UseCases.Commands.Movimientos.CrearMovimiento;
using Domain.Factory.Movimientos;
using Domain.Model.Movimientos;
using Domain.Repository.Categorias;
using Domain.Repository.Cuentas;
using Domain.Repository.Movimientos;
using Domain.Repository.Usuarios;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCases.Commands.Movimientos.ActualizarMovimiento
{
public class ActualizarMovimientoHandler : IRequestHandler<ActualizarMovimientoCommand, Guid>
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        private readonly IMovimientoFactory _movimientoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarMovimientoHandler(IMovimientoRepository movimientoRepository, ICuentaRepository cuentaRepository, ICategoriaRepository categoriaRepository, IUsuarioRepository usuarioRepository, IMovimientoFactory movimientoFactory, IUnitOfWork unitOfWort)
        {
            _movimientoRepository = movimientoRepository;
            _cuentaRepository = cuentaRepository;
            _categoriaRepository = categoriaRepository;
            _usuarioRepository = usuarioRepository;
            _movimientoFactory = movimientoFactory;
            _unitOfWork = unitOfWort;
        }

        public async Task<Guid> Handle(ActualizarMovimientoCommand request, CancellationToken cancellationToken)
        {
            var movimiento = await _movimientoRepository.FindByIdAsync(request.Id);
            var cuenta = await _cuentaRepository.FindByIdAsync(request.CuentaId);
            var categoria = await _categoriaRepository.FindByIdAsync(request.CategoriaId);
            var usuario = await _usuarioRepository.FindByIdAsync(categoria.UsuarioId);

            if (movimiento == null)
            {
                throw new BussinessRuleValidationException("Movimiento no encontrado");
            }
            if (cuenta == null)
            {
                throw new BussinessRuleValidationException("Cuenta no encontrada");
            }
            if (categoria == null)
            {
                throw new BussinessRuleValidationException("Categoría no encontrada");
            }

            if (request.Tipo == "ingreso")
            {
                var saldoCambio = request.Saldo - movimiento.Saldo;
                cuenta.Ingreso(saldoCambio);
                usuario.IngresoMontoTotal(saldoCambio);
                movimiento.editarMovimiento(request.CuentaId, request.CategoriaId, request.Descripcion, request.Tipo, request.Saldo);
                
            }
            else if (request.Tipo == "egreso")
            {
                var saldoCambio = request.Saldo - movimiento.Saldo;
                cuenta.Egreso(saldoCambio);
                usuario.EgresoMontoTotal(saldoCambio);
                movimiento.editarMovimiento(request.CuentaId, request.CategoriaId, request.Descripcion, request.Tipo, request.Saldo);
                
            }
            else
            {
                throw new BussinessRuleValidationException("Tipo de movimiento no válido");
            }

            await _movimientoRepository.UpdateAsync(movimiento);
            await _cuentaRepository.UpdateAsync(cuenta);
            await _usuarioRepository.UpdateAsync(usuario);
            await _unitOfWork.Commit();
            return movimiento.Id;
        }
    }
}