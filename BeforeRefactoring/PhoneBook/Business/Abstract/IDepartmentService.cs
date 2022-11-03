using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        public IResult UpdateDepartment(Department department);
        public IResult AddNewDepartment(Department department);
        public IDataResult<List<Department>> GetAllDepartment();
        public IDataResult<Department> GetDepartmentById(int personId);
    }
}
