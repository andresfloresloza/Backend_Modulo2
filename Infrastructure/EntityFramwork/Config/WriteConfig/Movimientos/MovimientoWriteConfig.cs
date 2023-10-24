using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Domain.Model.Movimientos;
using SharedKernel.ValueObjects.Transferencias;

namespace Infrastructure.EntityFramwork.Config.WriteConfig.Movimientos
{
    internal class MovimientoWriteConfig : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> builder)
        {

            var descripcionConverter = new ValueConverter<DescripcionValue, string>(
                nameValue => nameValue.Name,
                stringValue => new DescripcionValue(stringValue)
            );
          
            var saldoConverter = new ValueConverter<SaldoValue, decimal>(
                saldoValue => saldoValue.Value,
                decimalValue => new SaldoValue(decimalValue)
            );

            builder.ToTable("Movimiento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Descripcion).HasColumnName("descripcion").HasConversion(descripcionConverter);
            builder.Property(x => x.Tipo).HasColumnName("tipo");
            builder.Property(x => x.Saldo).HasColumnName("saldo").HasConversion(saldoConverter).HasPrecision(20, 2);
            builder.Property(x => x.Fecha).HasColumnName("fecha");
            builder.Property(x => x.CuentaId).HasColumnName("cuentaId");
            builder.Property(x => x.CategoriaId).HasColumnName("categoriaId");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}