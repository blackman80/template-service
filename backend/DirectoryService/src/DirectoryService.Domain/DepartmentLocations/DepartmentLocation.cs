using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentLocations.ValueObjects;
using DirectoryService.Domain.DepartmentPositions.ValueObjects;

namespace DirectoryService.Domain.DepartmentLocations
{
    public sealed class DepartmentLocation
    {
        private DepartmentLocation(
            DepartmentLocationId id,
            DepartmentId departmentId,
            LocationId locationId,
            bool isPrimary)
        {
            Id = id;
            DepartmentId = departmentId;
            LocationId = locationId;
            IsPrimary = isPrimary;
        }

        private DepartmentLocation()
        {
        } // для EF

        public DepartmentLocationId Id { get; }
        
        public DepartmentId DepartmentId { get; }

        public LocationId LocationId { get; }

        public bool IsPrimary { get; }

        public static Result<DepartmentLocation> Create(DepartmentId departmentId, LocationId locationId, bool isPrimary)
        {
            if (departmentId is null)
                return Result.Failure<DepartmentLocation>("Invalid departmentId");
            if (locationId is null)
                return Result.Failure<DepartmentLocation>("Invalid locationId");

            return new DepartmentLocation(
                DepartmentLocationId.Create(), departmentId, locationId, isPrimary);
        }
    }
}