using Application.Dto.Cuentas;
using Application.Dto.Movimientos;
using Application.UseCases.Queries.Cuentas;
using Application.UseCases.Queries.Movimientos;
using Infrastructure.EntityFramwork.Context;
using Infrastructure.EntityFramwork.ReadModel.Cuentas;
using Infrastructure.EntityFramwork.ReadModel.Movimientos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    internal class GetMovimientoCuentaHandler : IRequestHandler<GetMovimientoCuentaByIdQuery, List<MovimientoDto>>
    {
        private readonly DbSet<MovimientoReadModel> movimientos;

        public GetMovimientoCuentaHandler(ReadDbContext dbContext)
        {
            movimientos = dbContext.Movimientos;
        }

        public async Task<List<MovimientoDto>> Handle(GetMovimientoCuentaByIdQuery request, CancellationToken cancellationToken)
        {
            var CuentaMovimiento = await movimientos.AsNoTracking()
                .Where(x => x.CuentaId == request.CuentaId)
                .Select(cuenta => new MovimientoDto
                {
                    Id = cuenta.Id,
                    CuentaId = cuenta.CuentaId,
                    CategoriaId = cuenta.CategoriaId,
                    Descripcion = cuenta.Descripcion,
                    Tipo = cuenta.Tipo,
                    Saldo = cuenta.Saldo
                })
                .ToListAsync();

            return CuentaMovimiento;
        }
    }
}
