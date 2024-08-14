using CKB.Domain.Common.Models;

namespace CKB.Domain.ValueObjects;

public class TagName : ValueObject
{
    public string Value { get; private set; }

    private TagName()
    {
        Value = string.Empty; 
    } 

    public TagName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Tag name cannot be empty");

        Value = value.Trim();
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
