using CustomCRM.Domain.Commons.Enums.Services;

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

        public static Price? Create(decimal amount, Currency currency)
        {
            Validate(amount, currency);
            return new Price(amount, currency);
        }

        public static Price? Update(decimal amount, Currency currency)
        {
            Validate(amount, currency);
            return new Price(amount, currency);
        }

        private static void Validate(decimal amount, Currency currency)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Price must be greater than 0.");

            if (currency == null)
                throw new ArgumentNullException(nameof(currency), "Currency cannot be null.");
        }
    }
}
