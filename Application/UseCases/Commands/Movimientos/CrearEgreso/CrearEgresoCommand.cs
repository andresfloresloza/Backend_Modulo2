using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands.Movimientos.CrearEgreso
{
    public record CrearEgresoCommand : IRequest<Guid>
    {
        public Guid CuentaId { get; set; }
        public Guid CategoriaId { get; set; }

        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public decimal Saldo { get; set; }


        public CrearEgresoCommand(Guid cuentaId, Guid categoriaId, string descripcion, string tipo, decimal saldo)
        {
            CuentaId = cuentaId;
            CategoriaId = categoriaId;
            Descripcion = descripcion;
            Tipo = tipo;
            Saldo = saldo;
        }

    }
}
