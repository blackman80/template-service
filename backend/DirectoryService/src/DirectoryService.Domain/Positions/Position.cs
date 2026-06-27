using CSharpFunctionalExtensions;
using DirectoryService.Domain.Positions.ValueObjects;

namespace DirectoryService.Domain.Positions;

public class Position
{
    private Position(Name name, Description description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public Description? Description { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public Result ChangePosition(Name name, Description description)
    {
        Name = name;
        Description = description;

        return Result.Success();
    }

    public static Result<Position> Create(Name name, Description description)
    {
        return new Position(name, description);
    }
}