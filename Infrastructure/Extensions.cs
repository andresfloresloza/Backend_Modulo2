using Application;
using Domain.Repository.Categorias;
using Domain.Repository.Usuarios;
using Infrastructure.EntityFramwork.Context;
using Infrastructure.EntityFramwork.Repository.Usuarios;
using Infrastructure.EntityFramwork.Repository.Categorias;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Core;
using Infrastructure.EntityFramework;
using Domain.Repository.Cuentas;
using Infrastructure.EntityFramwork.Repository.Cuentas;
using Domain.Model.Usuarios;
using System.Reflection;
using Application.Security;
using Infrastructure.EntityFramework.Security;
using Domain.Repository.Movimientos;
using Infrastructure.EntityFramwork.Repository.Movimientos;

namespace Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAplication();
            var connectionString = configuration.GetConnectionString("DbConnectionString");
            services.AddDbContext<ReadDbContext>(context => { context.UseSqlServer(connectionString); });
            services.AddDbContext<WriteDbContext>(context => { context.UseSqlServer(connectionString); });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IMovimientoRepository, MovimientoRepository>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<AuthenticationSecurity>();

            return services;
        }
        
    }
}
