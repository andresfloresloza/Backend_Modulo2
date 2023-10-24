using MediatR;

namespace Application.UseCases.Commands.Movimientos.CrearIngreso
{
    public record CrearIngresoCommand : IRequest<Guid>
    {
        public Guid CuentaId { get; set; }
        public Guid CategoriaId { get; set; }

        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public decimal Saldo { get; set; }


        public CrearIngresoCommand(Guid cuentaId, Guid categoriaId, string descripcion, string tipo, decimal saldo)
        {
            CuentaId = cuentaId;
            CategoriaId = categoriaId;
            Descripcion = descripcion;
            Tipo = tipo;
            Saldo = saldo;
        }
    }
}
