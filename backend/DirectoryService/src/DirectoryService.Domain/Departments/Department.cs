using CSharpFunctionalExtensions;
using DirectoryService.Domain.Departments.ValueObjects;
using Path = DirectoryService.Domain.Departments.ValueObjects.Path;

namespace DirectoryService.Domain.Departments;

public class Department
{

    private Department(
        Name name,
        Slug slug,
        Identifier identifier,
        Path path,
        Guid? parentId,
        DepartmentTips departmentTip)
    {
        Id = Guid.NewGuid();
        Name = name;
        Slug = slug;
        Identifier = identifier;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
        Path = path;
        ParentId = parentId;
        IsActive = true;
        DepartmentTip = departmentTip;
    }

    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public Slug Slug { get; private set; }

    public Identifier Identifier { get; private set; }

    public Guid? ParentId { get; private set; }

    public DepartmentTips DepartmentTip { get; private set; }

    public enum DepartmentTips { rootUnit, subsidiaryDivision }

    public Path Path { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public Result Rename(Name newName, Identifier newIdentifier)
    {
        Name = newName;
        Identifier = newIdentifier;

        return Result.Success();
    }

    public static Result<Department> Create(
        Name name,
        Slug slug,
        Identifier identifier,
        Path path,
        Guid? parentId,
        DepartmentTips departmentTip)
    {
        departmentTip = parentId is null ? DepartmentTips.rootUnit : DepartmentTips.subsidiaryDivision;

        return new Department(name, slug, identifier, path, parentId, departmentTip);
    }
}