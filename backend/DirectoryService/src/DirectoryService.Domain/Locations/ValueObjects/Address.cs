using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Locations.ValueObjects;

public record Address
{
    private Address(string country, string city, string street, string house, string postalCode)
    {
        Country = country;
        City = city;
        Street = street;
        House = house;
        PostalCode = postalCode;
    }

    public string Country { get; }

    public string City { get; }

    public string Street { get; }

    public string House { get; }

    public string PostalCode { get; }

    // "В бд может быть несколько столбцов или jsonb" видимо это будет реализовываться позже
    public static Result<Address> Create(string country, string city, string street, string house, string postalCode)
    {
        return new Address(country, city, street, house, postalCode);
    }
}