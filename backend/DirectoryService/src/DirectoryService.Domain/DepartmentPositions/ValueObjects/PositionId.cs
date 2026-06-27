using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.DepartmentPositions.ValueObjects
{
    public record PositionId
    {
        private PositionId(Guid value) => Value = value;
        public Guid Value { get; }

        public static Result<PositionId> Create()
        {
            return new PositionId(Guid.NewGuid());
        }
    }
}