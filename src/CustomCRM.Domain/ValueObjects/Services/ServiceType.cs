
namespace CustomCRM.Domain.ValueObjects.Services
{
    public class ServiceType
    {
        public string Value { get; private set; }

        private ServiceType(string value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (ServiceType)obj;
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static ServiceType Create(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Service type cannot be null or empty", nameof(value));

            return new ServiceType(value);
        }
    }
}
