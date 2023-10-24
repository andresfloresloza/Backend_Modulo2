using Domain.Factory.Cuentas;

namespace Test.Domain
{
    public class TestCuenta
    {
        [Fact]
        public void CuentaCreation_Should_Correct()
        {
            var usuarioId = Guid.NewGuid(); ;
            var nombre = "Cuenta Principal";

            var factory = new CuentaFactory();
            var cuenta = factory.Crear(usuarioId, nombre);

            Assert.NotNull(cuenta);

            Assert.Equal(usuarioId, cuenta.UsuarioId);
            Assert.Equal(nombre, cuenta.Nombre);
        }
    }
}