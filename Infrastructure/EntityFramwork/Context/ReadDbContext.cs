using Infrastructure.EntityFramwork.Config.ReadConfig.Categorias;
using Infrastructure.EntityFramwork.Config.ReadConfig.Cuentas;
using Infrastructure.EntityFramwork.Config.ReadConfig.Movimientos;
using Infrastructure.EntityFramwork.Config.ReadConfig.Usuarios;
using Infrastructure.EntityFramwork.ReadModel.Categorias;
using Infrastructure.EntityFramwork.ReadModel.Cuentas;
using Infrastructure.EntityFramwork.ReadModel.Movimientos;
using Infrastructure.EntityFramwork.ReadModel.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramwork.Context
{
    internal class ReadDbContext : DbContext
    {
        public virtual DbSet<UsuarioReadModel> Usuarios { get; set; }
        public virtual DbSet<CuentaReadModel> Cuentas { get; set; }
        public virtual DbSet<CategoriaReadModel> Categorias { get; set; }
        public virtual DbSet<MovimientoReadModel> Movimientos { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<UsuarioReadModel>(new UsuarioReadConfig());
            modelBuilder.ApplyConfiguration<CuentaReadModel>(new CuentaReadConfig());
            modelBuilder.ApplyConfiguration<CategoriaReadModel>(new CategoriaReadConfig());
            modelBuilder.ApplyConfiguration<MovimientoReadModel>(new MovimientoReadConfig());
        }
    }
}
