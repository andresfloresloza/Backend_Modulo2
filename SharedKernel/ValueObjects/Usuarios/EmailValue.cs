using SharedKernel.Core;

namespace SharedKernel.ValueObjects.Usuarios
{
    public record EmailValue : ValueObject
    {
        public string Name { get; }

        public EmailValue(string name)
        {
            if (!IsValidEmailAddress(name))
            {
                throw new BussinessRuleValidationException("Invalid email address.");
            }

            Name = name;
        }

        private bool IsValidEmailAddress(string name)
        {

            return !string.IsNullOrWhiteSpace(name) && name.Contains("@");
        }

        public static implicit operator string(EmailValue value)
        {
            return value.Name;
        }

        public static implicit operator EmailValue(string name)
        {
            return new EmailValue(name);
        }
    }
}