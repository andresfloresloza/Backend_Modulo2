using Application.UseCases.Commands.Cuentas.CrearCuenta;
using Application.UseCases.Queries.Cuentas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/cuenta")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ILogger<CuentaController> _logger;
        private readonly IMediator _mediator;

        public CuentaController(IMediator mediator, ILogger<CuentaController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCuenta([FromBody] CrearCuentaCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la cuenta");
                return BadRequest();
            }
        }

        [Route("{usuarioId}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid usuarioId)
        {
            var query = new GetCuentaByIdQuery()
            {
                UsuarioId = usuarioId
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

    }
}
