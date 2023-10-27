using Application.UseCases.Commands.Transferencias.CrearTransferencia;
using Application.UseCases.Commands.Transferencias.EliminarTransferencia;
using Application.UseCases.Queries.Movimientos;
using Application.UseCases.Queries.Transferencias;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/transferencia")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly ILogger<TransferenciaController> _logger;
        private readonly IMediator _mediator;

        public TransferenciaController(IMediator mediator, ILogger<TransferenciaController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Route("insert")]
        [HttpPost]
        public async Task<IActionResult> CrearMovimiento([FromBody] CrearTransferenciaCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la transferencia");
                return BadRequest();
            }
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> EliminarMovimiento([FromBody] EliminarTransferenciaCommand command)
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

        [Route("cuenta/{cuentaOrigenId}")]
        [HttpGet]
        public async Task<IActionResult> GetCuenta([FromRoute] Guid cuentaOrigenId)
        {
            var query = new GetTransferenciaByIdQuery()
            {
                CuentaOrigenId = cuentaOrigenId
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
