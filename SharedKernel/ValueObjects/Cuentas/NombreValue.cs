using SharedKernel.Core;
using SharedKernel.Rules;

namespace SharedKernel.ValueObjects.Cuentas
{
    public record NombreValue : ValueObject
    {
        public string Name { get; }

        public NombreValue(string name)
        {
            CheckRule(new StringNotNullOrEmptyRule(name));
            if (name.Length > 100)
            {
                throw new BussinessRuleValidationException("NombreValue no puede tener mas de 100 caracteres");
            }
            Name = name;
        }

        public static implicit operator string(NombreValue value)
        {
            return value.Name;
        }

        public static implicit operator NombreValue(string name)
        {
            return new NombreValue(name);
        }
    }
}