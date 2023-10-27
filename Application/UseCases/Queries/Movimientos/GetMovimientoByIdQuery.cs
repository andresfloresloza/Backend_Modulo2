using Application.Dto.Movimientos;
using MediatR;

namespace Application.UseCases.Queries.Movimientos
{
    public class GetMovimientoByIdQuery : IRequest<List<MovimientoDto>>
    {
        public Guid Id { get; set; }

    }
}
