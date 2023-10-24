using Domain.Factory.Usuarios;

namespace Test.Domain
{
    public class TestUsuario
    {
        [Fact]
        public void UsuarioCreation_Should_Correct()
        {
            var firstName = "Luis Andres";
            var lastName = "Flores Loza";
            var email = "luisandresfloresloza@gmail.com";
            var password = "76680886";

            var factory = new UsuarioFactory();
            var usuario = factory.Crear(firstName, lastName, email, password);

            Assert.NotNull(usuario);

            Assert.Equal(firstName, usuario.FirstName);
            Assert.Equal(lastName, usuario.LastName);
            Assert.Equal(email, usuario.Email);
            Assert.Equal(password, usuario.Password);
        }
    }
}