using Application.UseCases.Commands.Categorias.CrearCategoria;
using Application.UseCases.Queries.Categorias;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator, ILogger<CategoriaController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCategoria([FromBody] CrearCategoriaCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la categoria");
                return BadRequest();
            }
        }
        [Route("{usuarioId}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid usuarioId)
        {
            var query = new GetCategoriaByIdQuery()
            {
                UsuarioId = usuarioId
            };
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
