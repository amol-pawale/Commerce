using System.ComponentModel.DataAnnotations;

namespace Commerce.Application.Validation;

public class NotEmptyGuidAttribute : ValidationAttribute
{
    public NotEmptyGuidAttribute()
        : base("The {0} field must not be an empty GUID.")
    {
    }

    public override bool IsValid(object? value)
    {
        return value is Guid guid && guid != Guid.Empty;
    }
}
