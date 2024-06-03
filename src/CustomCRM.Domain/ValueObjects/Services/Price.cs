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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Price)obj;
            return Amount == other.Amount && Currency == other.Currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }

        public static Price Create(decimal amount, string currency)
        {

            if (amount <= 0)
                throw new ArgumentException("Price cannot be negative or equal 0", nameof(amount));

            if (string.IsNullOrEmpty(currency))
                throw new ArgumentException("Currency cannot be null or empty", nameof(currency));

            return new Price(amount, currency);
        }       
    }
}
