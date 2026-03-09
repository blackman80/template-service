using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentPositions;
using DirectoryService.Domain.Departments.ValueObjects;
using DirectoryService.Domain.Locations;
using Path = DirectoryService.Domain.Departments.ValueObjects.Path;

namespace DirectoryService.Domain.Departments;

public class Department
{
    private List<Department> _children = [];
    private List<DepartmentPosition> _locations = [];
    private List<DepartmentPosition> _positions = [];

    private Department(
        Name name,
        Identifier identifier,
        Path path,
        short depth,
        Department? parent,
        IEnumerable<DepartmentPosition> locations,
        IEnumerable<DepartmentPosition> positions)
    {
        Id = Guid.NewGuid();
        Name = name;
        Identifier = identifier;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
        Path = path;
        Parent = parent;
        Depth = depth;
        _locations.AddRange(locations);
        _positions.AddRange(positions);
        IsActive = true;
    }

    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public Identifier Identifier { get; private set; }

    public Department? Parent { get; private set; }

    public IReadOnlyList<Department> Children => _children;

    public Path Path { get; private set; }

    public short Depth { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyList<DepartmentPosition> Locations => _locations;

    public IReadOnlyList<DepartmentPosition> Positions => _positions;

    public Result Rename(Name newName, Identifier newIdentifier)
    {
        Name = newName;
        Identifier = newIdentifier;

        return Result.Success();
    }

    public static Result<Department> Create(
        Name name,
        Path path,
        Identifier identifier,
        Department? parent,
        IEnumerable<Guid>? locationsIds,
        IEnumerable<Guid>? positionsIds)
    {
        short depth;
        if (parent?.Depth == null)
        {
            depth = 1;
        }
        else
        {
            depth = parent.Depth;
            depth++;
        }

        if (locationsIds == null || !locationsIds.Any())
        {
            return Result.Failure<Department>("Invalid locations");
        }

        var locations = locationsIds
            .Select(locationPositionIds => new DepartmentPosition(Guid.NewGuid(), locationPositionIds))
            .ToList();

        var positions = positionsIds
            .Select(locationPositionIds => new DepartmentPosition(Guid.NewGuid(), locationPositionIds))
            .ToList();

        return new Department(name, identifier, path, depth, parent, locations, positions);
    }
}