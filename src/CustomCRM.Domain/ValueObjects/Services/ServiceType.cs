namespace CustomCRM.Domain.ValueObjects.Services
{
    public class ServiceType
    {
        public string Value { get; private set; }

        private ServiceType(string value)
        {
            Value = value;
        }

        public static ServiceType Create(string value)
        {
            Validate(value);
            return new ServiceType(value);
        }

        public static ServiceType Update(string value)
        {
            Validate(value);
            return new ServiceType(value);
        }

        private static string? Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                return null;

            return value;
        }
    }
}
