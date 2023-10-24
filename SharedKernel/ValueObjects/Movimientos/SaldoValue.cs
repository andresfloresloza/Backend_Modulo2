using SharedKernel.Core;
using SharedKernel.Rules;

namespace SharedKernel.ValueObjects.Transferencias
{
    public record SaldoValue : ValueObject
    {
        public decimal Value { get; }

        public SaldoValue(decimal value)
        {
            CheckRule(new NotNullRule(value));
            Value = value;
        }

        public static implicit operator decimal(SaldoValue value)
        {
            return value.Value;
        }

        public static implicit operator SaldoValue(decimal value)
        {
            return new SaldoValue(value);
        }
    }
}