using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Departments.ValueObjects
{
    public record Slug
    {
        private Slug(string value)
        {
            Value = value;
        }

        public const int MaxLength = 150;

        public const int MinLength = 3;

        private const string Pattern = "^[a-z0-9]+(?:-[a-z0-9]+)*$";

        private static readonly Regex SlugRegex = new Regex(
            Pattern,
            RegexOptions.Compiled | RegexOptions.CultureInvariant,
            TimeSpan.FromSeconds(1)
        );

        public string Value { get; }

        public static Result<Slug> Create(string value)
        {
            #pragma warning disable CA1308 // Normalize strings to uppercase
            value = value.Trim().ToLowerInvariant();
            #pragma warning restore CA1308 // Normalize strings to uppercase

            if (string.IsNullOrWhiteSpace(value)
            || value.Length < MinLength
            || value.Length > MaxLength
            || !SlugRegex.IsMatch(value))
            {
                return Result.Failure<Slug>("Invalid Slug");
            }

            return new Slug(value);
        }
    }
}