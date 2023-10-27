using MediatR;

namespace Application.UseCases.Commands.Transferencias.EliminarTransferencia
{
    public record EliminarTransferenciaCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

    }
}