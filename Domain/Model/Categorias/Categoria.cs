using SharedKernel.Core;
using SharedKernel.ValueObjects.Categorias;

namespace Domain.Model.Categorias
{
    public class Categoria : AggregateRoot<Guid>
    {
        public Guid UsuarioId { get; private set; }

        public NombreValue Nombre { get; private set; }

        public Categoria() { }

        public Categoria(Guid usuarioId, string nombre)
        {
            if (usuarioId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El usuario no puede estar vacío.");
            }
            Id = Guid.NewGuid();
            UsuarioId = usuarioId;
            Nombre = nombre;

        }
    }
}
