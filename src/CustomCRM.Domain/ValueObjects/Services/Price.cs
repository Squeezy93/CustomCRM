namespace CustomCRM.Domain.ValueObjects.Services
{
    public class Price
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        private Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Price Create(decimal amount, string currency)
        {
            IsValid(amount, currency);
            return new Price(amount, currency);
        }

        public static Price Update(decimal amount, string currency)
        {
            IsValid(amount, currency);
            return new Price(amount, currency);
        }

        private static bool IsValid(decimal amount, string currency)
        {
            if (amount <= 0)
                throw new ArgumentException("Price cannot be negative or equal 0", nameof(amount));

            if (string.IsNullOrEmpty(currency))
                throw new ArgumentException("Currency cannot be null or empty", nameof(currency));

            return true;
        }
    }
}
