using Application.UseCases.Commands.Movimientos.CrearEgreso;
using Application.UseCases.Commands.Movimientos.CrearIngreso;
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

        [Route("ingreso")]
        [HttpPost]
        public async Task<IActionResult> CrearIngreso([FromBody] CrearIngresoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el ingreso");
                return BadRequest();
            }
        }
        [Route("egreso")]
        [HttpPost]
        public async Task<IActionResult> CrearEgreso([FromBody] CrearEgresoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el egreso");
                return BadRequest();
            }
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
        public async Task<IActionResult> Get([FromRoute] Guid categoriaId)
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
