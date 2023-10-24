using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Infrastructure.EntityFramwork.ReadModel.Categorias;

namespace Infrastructure.EntityFramwork.Config.ReadConfig.Categorias
{
    internal class CategoriaReadConfig : IEntityTypeConfiguration<CategoriaReadModel>
    {
        public void Configure(EntityTypeBuilder<CategoriaReadModel> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre");

            builder.Property(x => x.UsuarioId).HasColumnName("usuarioId");
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.UsuarioId);
        }
    }
}
