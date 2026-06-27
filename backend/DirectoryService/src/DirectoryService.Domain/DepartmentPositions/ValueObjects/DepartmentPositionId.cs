namespace DirectoryService.Domain.DepartmentPositions.ValueObjects
{
    public record DepartmentPositionId
    {
        private DepartmentPositionId(Guid value) => Value = value;

        public Guid Value { get; }

        public static DepartmentPositionId Create()
        {
            return new DepartmentPositionId(Guid.NewGuid());
        }
    }
}