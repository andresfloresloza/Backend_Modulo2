using Application.Dto.Cuentas;
using MediatR;


namespace Application.UseCases.Queries.Cuentas
{
    public class GetCuentaByIdQuery : IRequest<List<CuentaDto>>
    {
        public Guid UsuarioId { get; set; }

    }
}
