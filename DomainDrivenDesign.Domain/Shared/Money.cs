namespace DomainDrivenDesign.Domain.Shared
{
    public sealed record Money(decimal Amaount, Currency currency)
    {

        public static Money operator +(Money money1, Money money2)
        {
            if (money1.currency != money2.currency)
                throw new InvalidOperationException("Cannot add two Money values with different currencies.");
            return new Money(money1.Amaount + money2.Amaount, money1.currency);
        }

        public static Money operator -(Money money1, Money money2)
        {
            if (money1.currency != money2.currency)
                throw new InvalidOperationException("Cannot subtract two Money values with different currencies.");
            return new Money(money1.Amaount - money2.Amaount, money1.currency);
        }

        public static Money Zero() => new(0, Currency.None);
        public static Money Zero(Currency Currency) => new(0, Currency);

        public bool IsZero() => this == Zero(currency);
    }
}
