using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Locations.ValueObjects;

public record Timezone
{
    private const string Pattern = @"^[a-zA-Z]+/[a-zA-Z_]+$";

    private static readonly Regex TimezoneRegex = new Regex(
        Pattern,
        RegexOptions.Compiled,
        TimeSpan.FromSeconds(1)
    );
    private Timezone(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<Timezone> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) 
            || TimezoneRegex.IsMatch(value))
        {
            return Result.Failure<Timezone>("Incorrect Iana code line");
        }

        if (!TimeZoneInfo.TryFindSystemTimeZoneById(value, out TimeZoneInfo? timeZoneInfo))
        {
            return Result.Failure<Timezone>($"{timeZoneInfo} Incorrect Iana code");
        }

        return new Timezone(value);
    }
}