namespace DirectoryService.Domain.DepartmentLocations.ValueObjects
{
    public record DepartmentLocationId
    {
        private DepartmentLocationId(Guid value) => Value = value;
        public Guid Value { get; }

        public static DepartmentLocationId Create()
        {
            return new DepartmentLocationId(Guid.NewGuid());
        }
    }
}