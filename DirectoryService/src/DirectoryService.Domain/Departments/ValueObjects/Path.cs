using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Departments.ValueObjects;

public record Path
{
    private Path(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Path> Create(string bodyPath, string identifier)
    {
        var value = bodyPath + identifier;

        if (string.IsNullOrWhiteSpace(value)
            || Regex.IsMatch(value, @"^[A-Za-z.\-]+$"))
        {
            return Result.Failure<Path>("Invalid path");
        }

        return new Path(value);
    }
}