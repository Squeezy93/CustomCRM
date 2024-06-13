using CustomCRM.Domain.Commons;

namespace CustomCRM.Domain.ValueObjects.Services
{
    public class Price
    {
        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; }

        private Price(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Price Create(decimal amount, Currency currency)
        {
            IsValid(amount, currency);
            return new Price(amount, currency);
        }

        public static Price Update(decimal amount, Currency currency)
        {
            IsValid(amount, currency);
            return new Price(amount, currency);
        }

        private static bool IsValid(decimal amount, Currency currency)
        {
            if (amount <= 0)
                throw new ArgumentException("Price cannot be negative or equal 0", nameof(amount));           

            return true;
        }
    }
}
