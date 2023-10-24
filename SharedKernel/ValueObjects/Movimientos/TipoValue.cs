using SharedKernel.Core;
using SharedKernel.Rules;

namespace SharedKernel.ValueObjects.Transferencias
{
    public record TipoValue : ValueObject
    {
        public string Name { get; }

        public TipoValue(string name)
        {
            CheckRule(new StringNotNullOrEmptyRule(name));
            if (name.Length > 100)
            {
                throw new BussinessRuleValidationException("TipoValue no puede tener mas de 100 caracteres");
            }
            Name = name;
        }

        public static implicit operator string(TipoValue value)
        {
            return value.Name;
        }

        public static implicit operator TipoValue(string name)
        {
            return new TipoValue(name);
        }
    }
}
