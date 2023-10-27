using Application.UseCases.Commands.Movimientos.ActualizarMovimiento;
using Application.UseCases.Commands.Movimientos.CrearMovimiento;
using Application.UseCases.Commands.Movimientos.EliminarMovimiento;
using Application.UseCases.Queries.Movimientos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/movimiento")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly ILogger<MovimientoController> _logger;
        private readonly IMediator _mediator;

        public MovimientoController(IMediator mediator, ILogger<MovimientoController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Route("insert")]
        [HttpPost]
        public async Task<IActionResult> CrearMovimiento([FromBody] CrearMovimientoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el movimiento");
                return BadRequest();
            }
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> ActualizarMovimiento([FromBody] ActualizarMovimientoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el movimiento");
                return BadRequest();
            }
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> EliminarMovimiento([FromBody] EliminarMovimientoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDetalleById([FromRoute] Guid id)
        {
            var query = new GetMovimientoByIdQuery()
            {
                Id = id
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [Route("cuenta/{cuentaId}")]
        [HttpGet]
        public async Task<IActionResult> GetCuenta([FromRoute] Guid cuentaId)
        {
            var query = new GetMovimientoCuentaByIdQuery()
            {
                CuentaId = cuentaId
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [Route("categoria/{categoriaId}")]
        [HttpGet]
        public async Task<IActionResult> GetCategoria([FromRoute] Guid categoriaId)
        {
            var query = new GetMovimientoCategoriaByIdQuery()
            {
                CategoriaId = categoriaId
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
