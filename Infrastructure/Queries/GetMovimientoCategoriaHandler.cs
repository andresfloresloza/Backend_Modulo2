using Application.Dto.Movimientos;
using Application.UseCases.Queries.Movimientos;
using Infrastructure.EntityFramwork.Context;
using Infrastructure.EntityFramwork.ReadModel.Movimientos;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Queries
{
    internal class GetMovimientoCategoriaHandler : IRequestHandler<GetMovimientoCategoriaByIdQuery, List<MovimientoDto>>
    {
        private readonly DbSet<MovimientoReadModel> movimientos;

        public GetMovimientoCategoriaHandler(ReadDbContext dbContext)
        {
            movimientos = dbContext.Movimientos;
        }

        public async Task<List<MovimientoDto>> Handle(GetMovimientoCategoriaByIdQuery request, CancellationToken cancellationToken)
        {
            var CategoriaMovimiento = await movimientos.AsNoTracking()
                .Where(x => x.CategoriaId == request.CategoriaId)
                .Select(categoria => new MovimientoDto
                {
                    Id = categoria.Id,
                    CuentaId = categoria.CuentaId,
                    CategoriaId = categoria.CategoriaId,
                    Descripcion = categoria.Descripcion,
                    Tipo = categoria.Tipo,
                    Saldo = categoria.Saldo
                })
                .ToListAsync();

            return CategoriaMovimiento;
        }
    }
}