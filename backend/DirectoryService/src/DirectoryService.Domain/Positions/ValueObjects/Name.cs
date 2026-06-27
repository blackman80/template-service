using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Positions.ValueObjects;

public record Name
{
    public const int MaxLength = 100;
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
            return Result.Failure<Name>("Invalid name position");
        }

        return new Name(value);
    }
}