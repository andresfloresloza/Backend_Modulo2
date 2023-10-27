using MediatR;

namespace Application.UseCases.Commands.Transferencias.CrearTransferencia
{
    public record CrearTransferenciaCommand : IRequest<Guid>
    {
        public Guid CuentaOrigenId { get; set; }
        public Guid CuentaDestinoId { get; set; }
        public Guid UsuarioId { get; set; }
        public decimal Saldo { get; set; }


        public CrearTransferenciaCommand(Guid cuentaOrigenId, Guid cuentaDestinoId, Guid usuarioId, decimal saldo)
        {
            CuentaOrigenId = cuentaOrigenId;
            CuentaDestinoId = cuentaDestinoId;
            UsuarioId = usuarioId;
            Saldo = saldo;
        }
    }
}
