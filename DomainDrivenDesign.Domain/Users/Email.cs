namespace DomainDrivenDesign.Domain.Users
{
    public sealed record Email
    {
        public string Value { get; init; }
        public Email(string value)
        {
            if (value.Length < 5) throw new ArgumentException("Email must be at least 5 characters long.");
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Email cannot be null or empty.");
            if (!value.Contains("@")) throw new ArgumentException("Email must contain '@' character.");
            Value = value;
        }
    }
}
