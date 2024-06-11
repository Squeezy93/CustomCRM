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
            IsValid(value);
            return new ServiceType(value);
        }

        public static ServiceType Update(string value)
        {
            IsValid(value);
            return new ServiceType(value);
        }

        private static bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Service type cannot be null or empty", nameof(value));

            return true;
        }
    }
}
