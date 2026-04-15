namespace DomainDrivenDesign.Domain.Shared
{
    public sealed record Currency
    {
        internal static readonly Currency None = new("");
        public static readonly Currency USD = new("USD");
        public static readonly Currency TRY = new("TRY");
        public string Code { get; init; }

        private Currency(string code)
        {
            Code = code;
        }

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(x => x.Code == code) ?? throw new ArgumentException($"Invalid currency code: {code}");
        }

        public static IReadOnlyCollection<Currency> All = new[] { USD, TRY };


    }


}
