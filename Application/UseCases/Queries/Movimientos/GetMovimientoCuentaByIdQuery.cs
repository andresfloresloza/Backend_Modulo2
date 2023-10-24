using Application.Dto.Cuentas;
using Application.Dto.Movimientos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.Movimientos
{
    public class GetMovimientoCuentaByIdQuery : IRequest<List<MovimientoDto>>
    {
        public Guid CuentaId { get; set; }

    }
}
