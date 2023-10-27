using Application.Dto.Transferencias;
using MediatR;

namespace Application.UseCases.Queries.Transferencias
{
    public class GetTransferenciaByIdQuery : IRequest<List<TransferenciaDto>>
    {
        public Guid CuentaOrigenId { get; set; }

    }
}