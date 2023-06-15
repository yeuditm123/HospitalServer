using Dal;


namespace Bl.DTO
{
    class DepartmentTypeDto
    {
        public int DepartmentTypeId { get; set; }
        public string DepTypeName { get; set; }
        public DepartmentTypeDto(DepartmentType depType)
        {
            DepartmentTypeId = depType.DepartmentTypeId;
            DepTypeName = depType.DepTypeName;
        }
    }
}
