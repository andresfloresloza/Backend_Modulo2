using Domain.Factory.Categorias;

namespace Test.Domain
{
    public class TestCategoria
    {
        [Fact]
        public void CategoiaCreation_Should_Correct()
        {
            var usuarioId = Guid.NewGuid(); ;
            var nombre = "Transporte";
            var tipo = "Ingreso";

            var factory = new CategoriaFactory();
            var categoria = factory.Crear(usuarioId, nombre, tipo);

            Assert.NotNull(categoria);

            Assert.Equal(usuarioId, categoria.UsuarioId);
            Assert.Equal(nombre, categoria.Nombre);
            Assert.Equal(tipo, categoria.Tipo);
        }
    }
}