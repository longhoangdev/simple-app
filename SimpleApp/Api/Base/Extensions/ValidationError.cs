using FluentResults;

namespace SimpleApp.Api.Base.Extensions;

public class ValidationError : Error
{
    public string PropertyName { get; }

    private ValidationError(string propertyName)
        : base("Validation error occured")
    {
        PropertyName = propertyName;
    }

    public ValidationError(string propertyName, IEnumerable<string> messages)
        : this(propertyName)
    {
        foreach (var message in messages)
            Reasons.Add(new Error(message));
    }
}