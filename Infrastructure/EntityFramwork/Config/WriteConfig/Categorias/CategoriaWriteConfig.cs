using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Domain.Model.Categorias;
using SharedKernel.ValueObjects.Categorias;

namespace Infrastructure.EntityFramwork.Config.WriteConfig.Categorias
{
    internal class CategoriaWriteConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {

            var nameConverter = new ValueConverter<NombreValue, string>(
                nameValue => nameValue.Name,
                stringValue => new NombreValue(stringValue)
            );
            var categoryConverter = new ValueConverter<TipoValue, string>(
                nameValue => nameValue.Name,
                stringValue => new TipoValue(stringValue)
            );

            builder.ToTable("Categoria");
            builder.HasKey(x => x.Id); 
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre").HasConversion(nameConverter);
            builder.Property(x => x.Tipo).HasColumnName("tipo").HasConversion(categoryConverter);
            builder.Property(x => x.UsuarioId).HasColumnName("usuarioId");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}