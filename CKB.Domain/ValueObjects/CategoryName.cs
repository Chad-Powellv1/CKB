using CKB.Domain.Common.Models;

namespace CKB.Domain.ValueObjects;

public class CategoryName : ValueObject
{
    public string Value { get; private set; }

    private CategoryName()
    {
        Value = string.Empty;
    }

    public CategoryName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Category name cannot be empty");

        Value = value.Trim();
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
