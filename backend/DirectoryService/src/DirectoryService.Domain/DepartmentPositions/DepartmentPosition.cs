using CSharpFunctionalExtensions;
using DirectoryService.Domain.DepartmentPositions.ValueObjects;

namespace DirectoryService.Domain.DepartmentPositions
{
    public sealed class DepartmentPosition
    {
        private DepartmentPosition(
            DepartmentPositionId id,
            PositionId positionId,
            DepartmentId departmentId)
        {
            Id = id;
            PositionId = positionId;
            DepartmentId = departmentId;
        }

        private DepartmentPosition() { } // для EF

        public DepartmentPositionId Id { get; private set; }

        public PositionId PositionId { get; private set; }

        public DepartmentId DepartmentId { get; private set; }


        public static Result<DepartmentPosition> Create(DepartmentId departmentId, PositionId positionId)
        {
            if (positionId is null)
                return Result.Failure<DepartmentPosition>("Invalid positionId");
            if (departmentId is null)
                return Result.Failure<DepartmentPosition>("Invalid departmentId");

            return new DepartmentPosition(
                DepartmentPositionId.Create(), positionId, departmentId);
        }
    }
}