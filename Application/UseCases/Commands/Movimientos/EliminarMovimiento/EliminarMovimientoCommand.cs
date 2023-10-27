using MediatR;

namespace Application.UseCases.Commands.Movimientos.EliminarMovimiento
{
    public record EliminarMovimientoCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

    }
}