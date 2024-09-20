using System.ComponentModel.DataAnnotations;
using AmnPardazJabari.Domain.Abstractions.Entities;
using AmnPardazJabari.Domain.Exceptions;

namespace AmnPardazJabari.Domain.TodoLists.ValueObjects;

public class Description : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    private Description()
    {
    }

    public Description(string value)
    {
        IsNullOrEmptyValidation(value);
        Value = value;
    }

    public string Value { get; set; }

    private void IsNullOrEmptyValidation(string value)
    {
        if (string.IsNullOrEmpty(value)) throw new NullReferenceException();
    }

    private void LengthValidation(string value)
    {
        if (value.Length < 5 || value.Length > 150) throw new ValidationException();
    }
}