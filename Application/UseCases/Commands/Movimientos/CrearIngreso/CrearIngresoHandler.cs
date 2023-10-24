using Domain.Factory.Movimientos;
using Domain.Repository.Categorias;
using Domain.Repository.Cuentas;
using Domain.Repository.Movimientos;
using Domain.Repository.Usuarios;
using MassTransit;
using MediatR;
using SharedKernel.Core;
using System.Threading;

namespace Application.UseCases.Commands.Movimientos.CrearIngreso
{
    public class CrearIngresoHandler : IRequestHandler<CrearIngresoCommand, Guid>
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        private readonly IMovimientoFactory _movimientoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearIngresoHandler(IMovimientoRepository movimientoRepository, ICuentaRepository cuentaRepository, ICategoriaRepository categoriaRepository, IUsuarioRepository usuarioRepository, IMovimientoFactory movimientoFactory, IUnitOfWork unitOfWort)
        {
            _movimientoRepository = movimientoRepository;
            _cuentaRepository = cuentaRepository;
            _categoriaRepository = categoriaRepository;
            _usuarioRepository = usuarioRepository;
            _movimientoFactory = movimientoFactory;
            _unitOfWork = unitOfWort;
        }

        public async Task<Guid> Handle(CrearIngresoCommand request, CancellationToken cancellationToken)
        {
            var cuenta = await _cuentaRepository.FindByIdAsync(request.CuentaId);
            var categoria = await _categoriaRepository.FindByIdAsync(request.CategoriaId);
            var usuario = await _usuarioRepository.FindByIdAsync(categoria.UsuarioId);

            if (cuenta == null)
            {
                throw new BussinessRuleValidationException("Cuenta no encontrada");
            }
            if (categoria == null)
            {
                throw new BussinessRuleValidationException("Categoría no encontrada");
            }


            var movimiento = _movimientoFactory.Crear(
                request.CuentaId,
                request.CategoriaId,
                request.Descripcion,
                request.Tipo,
                request.Saldo
            );


            await _movimientoRepository.CreateAsync(movimiento);

            cuenta.Ingreso(request.Saldo);
            await _cuentaRepository.UpdateAsync(cuenta);

            usuario.IngresoMontoTotal(request.Saldo);
            await _usuarioRepository.UpdateAsync(usuario);

            await _unitOfWork.Commit();
            return movimiento.Id;
        }
    }
}