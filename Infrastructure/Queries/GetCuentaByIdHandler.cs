using Application.Dto.Cuentas;
using Application.UseCases.Queries.Cuentas;
using Domain.Model.Cuentas;
using Infrastructure.EntityFramwork.Context;
using Infrastructure.EntityFramwork.ReadModel.Cuentas;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    internal class GetCuentaByIdHandler : IRequestHandler<GetCuentaByIdQuery, List<CuentaDto>>
    {
        private readonly DbSet<CuentaReadModel> cuentas;

        public GetCuentaByIdHandler(ReadDbContext dbContext)
        {
            cuentas = dbContext.Cuentas;
        }

        public async Task<List<CuentaDto>> Handle(GetCuentaByIdQuery request, CancellationToken cancellationToken)
        {
            var cuentasDelUsuario = await cuentas.AsNoTracking()
                .Where(x => x.UsuarioId == request.UsuarioId)
                .Select(cuenta => new CuentaDto
                {
                    Id = cuenta.Id,
                    UsuarioId = cuenta.UsuarioId,
                    Nombre = cuenta.Nombre,
                    Saldo = cuenta.Saldo
                })
                .ToListAsync();

            return cuentasDelUsuario;
        }
    }
}
