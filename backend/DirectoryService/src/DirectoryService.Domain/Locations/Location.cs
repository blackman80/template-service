using CSharpFunctionalExtensions;
using DirectoryService.Domain.Locations.ValueObjects;

namespace DirectoryService.Domain.Locations;

public class Location
{
    private Location(Name name, Address address, Timezone timezone)
    {
        Id = Guid.NewGuid();
        Name = name;
        Address = address;
        Timezone = timezone;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public Guid Id { get; private set; }

    public Name Name { get; private set; }

    public Address Address { get; private set; }

    public Timezone Timezone { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public Result ChangeLocation(
        Name newName,
        Address newAddress,
        Timezone newTimezone)
    {
        Name = newName;
        Address = newAddress;
        Timezone = newTimezone;

        return Result.Success();
    }

    public static Result<Location> Create(
        Name name,
        Address address,
        Timezone timezone)
    {
        return new Location(name, address, timezone);
    }
}