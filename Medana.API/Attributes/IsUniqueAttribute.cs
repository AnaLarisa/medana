using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Medana.API.Entities;

namespace Medana.API.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class IsUniqueAttribute : ValidationAttribute
{
    private readonly Type _contextType;

    public IsUniqueAttribute(Type contextType)
    {
        _contextType = contextType;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var dbContext = (DbContext)validationContext.GetService(_contextType);
        var propertyName = validationContext.MemberName;
        var dbSet = dbContext.Set<Patient>();
        var exists = dbSet.Any(e => EF.Property<object>(e, propertyName).Equals(value));

        if (exists)
        {
            return new ValidationResult($"The value '{value}' for '{propertyName}' already exists in the database.");
        }

        return ValidationResult.Success;
    }
}
