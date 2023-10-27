using Application.Dto.Movimientos;
using Application.UseCases.Queries.Movimientos;
using Infrastructure.EntityFramwork.Context;
using Infrastructure.EntityFramwork.ReadModel.Movimientos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    internal class GetMovimientoByIdHandler : IRequestHandler<GetMovimientoByIdQuery, List<MovimientoDto>>
    {
        private readonly DbSet<MovimientoReadModel> movimientos;

        public GetMovimientoByIdHandler(ReadDbContext dbContext)
        {
            movimientos = dbContext.Movimientos;
        }

        public async Task<List<MovimientoDto>> Handle(GetMovimientoByIdQuery request, CancellationToken cancellationToken)
        {
            var Movimiento = await movimientos.AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(movimiento => new MovimientoDto
                {
                    Id = movimiento.Id,
                    Cuenta = movimiento.Cuenta.Nombre,
                    Categoria = movimiento.Categoria.Nombre,
                    Descripcion = movimiento.Descripcion,
                    Tipo = movimiento.Tipo,
                    Saldo = movimiento.Saldo
                })
                .ToListAsync();

            return Movimiento;
        }
    }
}