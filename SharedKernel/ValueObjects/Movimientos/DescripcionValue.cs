using SharedKernel.Core;
using SharedKernel.Rules;

namespace SharedKernel.ValueObjects.Transferencias
{
    public record DescripcionValue : ValueObject
    {
        public string Name { get; }

        public DescripcionValue(string name)
        {
            CheckRule(new StringNotNullOrEmptyRule(name));
            if (name.Length > 200)
            {
                throw new BussinessRuleValidationException("DescripcionValue no puede tener mas de 200 caracteres");
            }
            Name = name;
        }

        public static implicit operator string(DescripcionValue value)
        {
            return value.Name;
        }

        public static implicit operator DescripcionValue(string name)
        {
            return new DescripcionValue(name);
        }
    }
}
