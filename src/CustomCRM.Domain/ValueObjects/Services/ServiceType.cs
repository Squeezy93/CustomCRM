namespace CustomCRM.Domain.ValueObjects.Services
{
    public class ServiceType
    {
        public string Value { get; private set; }

        private ServiceType(string value)
        {
            Value = value;
        }

        public static ServiceType? Create(string value)
        {
            Validate(value);
            return new ServiceType(value);
        }

        public static ServiceType? Update(string value)
        {
            Validate(value);
            return new ServiceType(value);
        }

        private static void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Service type cannot be null, whitespace or empty", nameof(value));            
        }
    }
}
