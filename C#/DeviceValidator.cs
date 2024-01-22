using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class IdRequiredAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        string id = value as string;
        return !string.IsNullOrWhiteSpace(id);
    }
}

public class CodeRangeAttribute : ValidationAttribute
{
    private readonly int _min;
    private readonly int _max;

    public CodeRangeAttribute(int min, int max)
    {
        _min = min;
        _max = max;
    }

    public override bool IsValid(object value)
    {
        if (value is int code)
        {
            return code >= _min && code <= _max;
        }

        return false;
    }
}

public class MaxLengthAttribute : ValidationAttribute
{
    private readonly int _maxLength;

    public MaxLengthAttribute(int maxLength)
    {
        _maxLength = maxLength;
    }

    public override bool IsValid(object value)
    {
        if (value is string stringValue)
        {
            return stringValue.Length <= _maxLength;
        }

        return false;
    }
}

class Device
{
    [IdRequired(ErrorMessage = "ID Property Requires Value")]
    public string Id { get; set; }

    [CodeRange(10, 100, ErrorMessage = "Code value must be in the range of 10 - 100")]
    public int Code { get; set; }

    [MaxLength(100, ErrorMessage = "Max of 100 Characters are allowed")]
    public string Description { get; set; }
}

class ObjectValidator
{
    public static bool Validate(object obj, out List<string> errors)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(obj, null, null);

        bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
        errors = new List<string>();

        if (!isValid)
        {
            foreach (var validationResult in validationResults)
            {
                errors.Add(validationResult.ErrorMessage);
            }
        }

        return isValid;
    }
}

class Program
{
    static void Main()
    {
        Device deviceObj = new Device { Id = "", Code = 5, Description = "Valid Description" };
        List<string> errors;
        bool isValid = ObjectValidator.Validate(deviceObj, out errors);

        if (!isValid)
        {
            foreach (string item in errors)
            {
                Console.WriteLine(item);
            }
        }
    }
}
