using SharedKernel.Core;
using SharedKernel.Rules;

namespace SharedKernel.ValueObjects.Usuarios
{
    public record MontoTotalValue : ValueObject
    {
        public decimal Value { get; }

        public MontoTotalValue(decimal value)
        {
            CheckRule(new NotNullRule(value));
            Value = value;
        }

        public static implicit operator decimal(MontoTotalValue value)
        {
            return value.Value;
        }

        public static implicit operator MontoTotalValue(decimal value)
        {
            return new MontoTotalValue(value);
        }
    }
}