using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Domain.Model.Cuentas;
using SharedKernel.ValueObjects.Cuentas;

namespace Infrastructure.EntityFramwork.Config.WriteConfig.Cuentas
{
    internal class CuentaWriteConfig : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {

            var nameConverter = new ValueConverter<NombreValue, string>(
                nameValue => nameValue.Name,
                stringValue => new NombreValue(stringValue)
            );

            var saldoConverter = new ValueConverter<SaldoValue, decimal>(
                saldoValue => saldoValue.Value,
                decimalValue => new SaldoValue(decimalValue)
            );

            builder.ToTable("Cuenta");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre").HasConversion(nameConverter);
            builder.Property(x => x.Saldo).HasColumnName("saldo").HasConversion(saldoConverter).HasPrecision(20, 2);
            builder.Property(x => x.UsuarioId).HasColumnName("usuarioId");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}