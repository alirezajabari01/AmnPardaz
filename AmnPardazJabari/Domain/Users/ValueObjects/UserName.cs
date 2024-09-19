using AmnPardazJabari.Domain.Abstractions.Entities;
using AmnPardazJabari.Domain.Exceptions;

namespace AmnPardazJabari.Domain.Users.ValueObjects;

public sealed class UserName : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private UserName()
    {
    }

    public UserName(string value)
    {
        IsNullOrEmptyValidation(value);
        Value = value;
    }

    public string Value { get; set; }

    private void IsNullOrEmptyValidation(string value)
    {
        if (string.IsNullOrEmpty(value)) throw new EmptyOrNullNameException();
    }
}