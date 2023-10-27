using Application.Dto.Transferencias;
using Application.UseCases.Queries.Transferencias;
using Infrastructure.EntityFramwork.Context;
using Infrastructure.EntityFramwork.ReadModel.Movimientos;
using Infrastructure.EntityFramwork.ReadModel.Transferencias;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    internal class GetTransferenciaByIdHandler : IRequestHandler<GetTransferenciaByIdQuery, List<TransferenciaDto>>
    {
        private readonly DbSet<TransferenciaReadModel> transferencias;

        public GetTransferenciaByIdHandler(ReadDbContext dbContext)
        {
            transferencias = dbContext.Transferencias;
        }

        public async Task<List<TransferenciaDto>> Handle(GetTransferenciaByIdQuery request, CancellationToken cancellationToken)
        {
            var Transferencia = await transferencias.AsNoTracking()
                .Where(x => x.CuentaOrigenId == request.CuentaOrigenId)
                .Select(transferencia => new TransferenciaDto
                {
                    Id = transferencia.Id,
                    CuentaOrigen = transferencia.CuentaOrigen.Nombre,
                    CuentaDestino = transferencia.CuentaDestino.Nombre,
                    Usuario = transferencia.Usuario.FirstName + " " + transferencia.Usuario.LastName,
                    Saldo = transferencia.Saldo
                })
                .ToListAsync();

            return Transferencia;
        }
    }
}