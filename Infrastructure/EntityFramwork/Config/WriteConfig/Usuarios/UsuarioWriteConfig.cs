using Domain.Model.Usuarios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using SharedKernel.ValueObjects.Usuarios;

namespace Infrastructure.EntityFramwork.Config.WriteConfig.Usuarios
{
    internal class UsuarioWriteConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            var firstNameConverter = new ValueConverter<FirstNameValue, string>(
                firstNameValue => firstNameValue.Name,
                stringValue => new FirstNameValue(stringValue)
            );

            var lastNameConverter = new ValueConverter<LastNameValue, string>(
               lastNameValue => lastNameValue.Name,
               stringValue => new LastNameValue(stringValue)
           );

            var emailConverter = new ValueConverter<EmailValue, string>(
                emailValue => emailValue.Name,
                stringValue => new EmailValue(stringValue)
            );
            var montoConverter = new ValueConverter<MontoTotalValue, decimal>(
                montoValue => montoValue.Value,
                decimalValue => new MontoTotalValue(decimalValue)
            );

            builder.ToTable("Usuario");
            builder.Property(x => x.Id).HasColumnName("usuarioId");
            builder.Property(x => x.FirstName).HasColumnName("firstName").HasConversion(firstNameConverter);
            builder.Property(x => x.LastName).HasColumnName("lastName").HasConversion(lastNameConverter);
            builder.Property(x => x.Email).HasColumnName("email").HasConversion(emailConverter);
            builder.Property(x => x.Password).HasColumnName("password");
            builder.Property(x => x.MontoTotal).HasColumnName("montoTotal").HasConversion(montoConverter);

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}

