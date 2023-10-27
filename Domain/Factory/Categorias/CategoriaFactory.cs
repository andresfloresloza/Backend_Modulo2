using Domain.Model.Categorias;

namespace Domain.Factory.Categorias
{
    public class CategoriaFactory : ICategoriaFactory
    {
        public Categoria Crear(Guid UsuarioId, string nombre, string tipo)
        {
            return new Categoria(UsuarioId, nombre, tipo);
        }
    }
}
