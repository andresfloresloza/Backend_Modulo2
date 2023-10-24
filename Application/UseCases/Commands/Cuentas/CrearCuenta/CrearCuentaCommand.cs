using MediatR;

namespace Application.UseCases.Commands.Cuentas.CrearCuenta
{
    public record CrearCuentaCommand : IRequest<Guid>
    {
        public Guid UsuarioId { get; set; }

        public string Nombre { get; set; }


        public CrearCuentaCommand(Guid usuarioId, string nombre)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
        }
    }
}
