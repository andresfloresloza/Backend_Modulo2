using Application.UseCases.Commands.Movimientos.CrearEgreso;
using Application.UseCases.Commands.Movimientos.CrearIngreso;
using Domain.Model.Usuarios;

namespace Test.Application.UseCases.Commands
{
    public class CrearMovimientoCommandTest
    {
        [Fact]
        public void CrearMovimientoIngresoCommand_DataValid()
        {
            var usuario = new Usuario("Luis Andres", "Flores Loza", "luisandresfloresloza@gmail.com","76680886");

            var cuentaId = Guid.NewGuid();
            var categoriaId = Guid.NewGuid(); ;
            var descripcion = "Compra de Accesorios";
            var tipo = "Ingreso";
            var saldo = 2000;
            var command = new CrearIngresoCommand(cuentaId, categoriaId, descripcion, tipo, saldo);

            Assert.Equal(cuentaId, command.CuentaId);
            Assert.Equal(categoriaId, command.CategoriaId);
            Assert.Equal(descripcion, command.Descripcion);
            Assert.Equal(tipo, command.Tipo);
            Assert.Equal(saldo, command.Saldo);

            usuario.IngresoMontoTotal(saldo);
            Assert.Equal(saldo, usuario.MontoTotal);
        }

        [Fact]
        public void CrearMovimientoEgresoCommand_DataValid()
        {
            var usuario = new Usuario("Luis Andres", "Flores Loza", "luisandresfloresloza@gmail.com", "76680886");

            var cuentaId = Guid.NewGuid();
            var categoriaId = Guid.NewGuid(); ;
            var descripcion = "Compra de Accesorios";
            var tipo = "Ingreso";
            var saldo = 150;
            var command = new CrearEgresoCommand(cuentaId, categoriaId, descripcion, tipo, saldo);

            Assert.Equal(cuentaId, command.CuentaId);
            Assert.Equal(categoriaId, command.CategoriaId);
            Assert.Equal(descripcion, command.Descripcion);
            Assert.Equal(tipo, command.Tipo);
            Assert.Equal(saldo, command.Saldo);

            usuario.EgresoMontoTotal(-saldo);
            Assert.Equal(saldo, usuario.MontoTotal);
        }
    }
}
