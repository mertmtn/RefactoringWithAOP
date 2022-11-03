using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        public void UpdateDepartment(Department department);
        public void AddNewDepartment(Department department);
        public List<Department> GetAllDepartment();
        public Department GetDepartmentById(int personId);
    }
}
