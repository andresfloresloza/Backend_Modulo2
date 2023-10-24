using Domain.Model.Categorias;
using Domain.Model.Cuentas;
using SharedKernel.Core;
using SharedKernel.ValueObjects.Usuarios;

namespace Domain.Model.Usuarios
{
    public class Usuario : AggregateRoot<Guid>
    {
        public FirstNameValue FirstName { get; private set; }

        public LastNameValue LastName { get; private set; }

        public EmailValue Email { get; private set; }

        public string Password { get; private set; }

        public MontoTotalValue MontoTotal { get; private set; }

        public List<Cuenta> Cuentas { get; private set; } = new List<Cuenta>();
        public List<Categoria> Categorias { get; private set; } = new List<Categoria>();


        public Usuario() { }
        public Usuario(string firstName, string lastName, string email, string password)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            MontoTotal = 0;

        }

        public void AñadirCuentaPorDefecto(Guid Id, string nombre)
        {
            var cuentaPorDefecto = new Cuenta(Id, nombre);
            Cuentas.Add(cuentaPorDefecto);
        }
        public void AñadirCategoriaPorDefecto(Guid Id, string nombre)
        {
            var categoriaPorDefecto = new Categoria(Id, nombre);
            Categorias.Add(categoriaPorDefecto);
        }

        public void AñadirPorDefecto(Guid Id)
        {
            AñadirCuentaPorDefecto(Id, "Cuenta Principal");
            AñadirCategoriaPorDefecto(Id, "Transporte");
            AñadirCategoriaPorDefecto(Id, "Alimentos");
            AñadirCategoriaPorDefecto(Id, "Entretenimiento");
        }

        public void IngresoMontoTotal(decimal monto)
        {
            MontoTotal += monto;
        }
        public void EgresoMontoTotal(decimal monto)
        {
            MontoTotal -= monto;
        }
    }
}
