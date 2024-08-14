using CKB.Domain.Common.Models;

namespace CKB.Domain.ValueObjects;

public class Slug : ValueObject
{
    public string Value { get; private set; }

    private Slug()
    {
        Value = string.Empty; 
    }

    public Slug(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Slug cannot be empty");

        Value = GenerateSlug(value);
    }

    private string GenerateSlug(string value)
    {
        // Simple slug generation logic
        return value.ToLower().Replace(" ", "-").Trim();
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}