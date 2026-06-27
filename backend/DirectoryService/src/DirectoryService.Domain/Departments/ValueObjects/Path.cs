using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Departments.ValueObjects;

public record Path
{
    private Path(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Path> Create(Slug[] slugs) //identifier нужен ли вообще теперь?
    {
        var value = string.Join("/", slugs);
        value = value.Trim();

        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<Path>("Invalid path");

        return new Path(value);
    }
}