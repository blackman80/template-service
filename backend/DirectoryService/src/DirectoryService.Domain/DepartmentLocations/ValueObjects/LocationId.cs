using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.DepartmentLocations.ValueObjects
{
    public record LocationId
    {
        private LocationId(Guid value) => Value = value;
        public Guid Value { get; }

        public static Result<LocationId> Create()
        {
            return new LocationId(Guid.NewGuid());
        }
    }
}
