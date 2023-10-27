using MediatR;

namespace Application.UseCases.Commands.Categorias.CrearCategoria
{
    public record CrearCategoriaCommand : IRequest<Guid>
    {
        public Guid UsuarioId { get; set; }

        public string Nombre { get; set; }
        public string Tipo { get; set; }

        public CrearCategoriaCommand(Guid usuarioId, string nombre, string tipo)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Tipo = tipo;
        }
    }
}
