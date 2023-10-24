using SharedKernel.Core;
using SharedKernel.Rules;

namespace SharedKernel.ValueObjects.Usuarios
{
    public record FirstNameValue : ValueObject
    {
        public string Name { get; }

        public FirstNameValue(string name)
        {
            CheckRule(new StringNotNullOrEmptyRule(name));
            if (name.Length > 50)
            {
                throw new BussinessRuleValidationException("FirstName no puede tener mas de 50 caracteres");
            }
            Name = name;
        }

        public static implicit operator string(FirstNameValue value)
        {
            return value.Name;
        }

        public static implicit operator FirstNameValue(string name)
        {
            return new FirstNameValue(name);
        }
    }
}

