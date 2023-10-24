using Application.UseCases.Commands.Usuarios.CrearUsuario;
using Application.UseCases.Commands.Usuarios.Login;
using Application.UseCases.Queries.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/usuario/")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator, ILogger<UsuarioController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CrearUsuario([FromBody] CrearUsuarioCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el usuario");
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUsuario([FromBody] LoginCommand command)
        {
            var token = await _mediator.Send(command);

            if (token != null)
            {
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }

        [Route("{usuarioId}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid usuarioId)
        {
            var query = new GetUsuarioByIdQuery()
            {
                UsuarioId = usuarioId
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
