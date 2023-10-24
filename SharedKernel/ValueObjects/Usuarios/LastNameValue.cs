using SharedKernel.Core;
using SharedKernel.Rules;

namespace SharedKernel.ValueObjects.Usuarios
{
    public record LastNameValue : ValueObject
    {
        public string Name { get; }

        public LastNameValue(string name)
        {
            CheckRule(new StringNotNullOrEmptyRule(name));
            if (name.Length > 50)
            {
                throw new BussinessRuleValidationException("LastNameValue no puede tener mas de 50 caracteres");
            }
            Name = name;
        }

        public static implicit operator string(LastNameValue value)
        {
            return value.Name;
        }

        public static implicit operator LastNameValue(string name)
        {
            return new LastNameValue(name);
        }
    }
}