using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Departments.ValueObjects;

public record Name
{
    public const int MaxLength = 150;
    public const int MinLength = 3;
    private Name(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Name> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < MinLength
                                             || value.Length > MaxLength)
        {
            return Result.Failure<Name>("Invalid name");
        }

        return new Name(value);
    }
}