
using Domain.Factory.Movimientos;

namespace Test.Domain
{
    public class TestMovimiento
    {
        [Fact]
        public void MovimientoIngresoCreation_Should_Correct()
        {
            var cuentaId = Guid.NewGuid();
            var categoriaId = Guid.NewGuid(); ;
            var descripcion = "Compra de Accesorios";
            var tipo = "Ingreso";
            var saldo = 2000;

            var factory = new MovimientoFactory();
            var movimiento = factory.Crear(cuentaId, categoriaId, descripcion, tipo, saldo);

            Assert.NotNull(movimiento);

            Assert.Equal(cuentaId, movimiento.CuentaId);
            Assert.Equal(categoriaId, movimiento.CategoriaId);
            Assert.Equal(descripcion, movimiento.Descripcion);
            Assert.Equal(tipo, movimiento.Tipo);
            Assert.Equal(saldo, movimiento.Saldo);

        }

        [Fact]
        public void MovimientoEgresoCreation_Should_Correct()
        {
            var cuentaId = Guid.NewGuid();
            var categoriaId = Guid.NewGuid(); ;
            var descripcion = "Compra de Accesorios";
            var tipo = "Egreso";
            var saldo = 500;

            var factory = new MovimientoFactory();
            var movimiento = factory.Crear(cuentaId, categoriaId, descripcion, tipo, saldo);

            Assert.NotNull(movimiento);

            Assert.Equal(cuentaId, movimiento.CuentaId);
            Assert.Equal(categoriaId, movimiento.CategoriaId);
            Assert.Equal(descripcion, movimiento.Descripcion);
            Assert.Equal(tipo, movimiento.Tipo);
            Assert.Equal(saldo, movimiento.Saldo);

        }
    }
}