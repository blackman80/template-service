using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.DepartmentPositions.ValueObjects
{
    public record DepartmentId
    {
        private DepartmentId(Guid value) => Value = value;
        public Guid Value { get; }

        public static Result<DepartmentId> Create()
        {
            return new DepartmentId(Guid.NewGuid());
        }
    }
}