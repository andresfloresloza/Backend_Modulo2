using Application.Dto.Usuarios;
using MediatR;

namespace Application.UseCases.Queries.Usuarios
{
    public class GetUsuarioByIdQuery : IRequest<List<UsuarioDto>>
    {
        public Guid UsuarioId { get; set; }

    }
}
