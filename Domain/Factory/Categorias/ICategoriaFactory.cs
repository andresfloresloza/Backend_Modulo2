using Domain.Model.Categorias;

namespace Domain.Factory.Categorias
{
    public interface ICategoriaFactory
    {
        Categoria Crear(Guid usuarioId, string nombre);
    }
}
