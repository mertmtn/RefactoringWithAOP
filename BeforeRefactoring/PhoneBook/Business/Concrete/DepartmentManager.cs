using Business.Abstract;
using Data.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Logging; 

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        private readonly ILogger<DepartmentManager> _logger;
        public DepartmentManager(IDepartmentDal departmentDal, ILogger<DepartmentManager> logger)
        {
            _logger = logger;
            _departmentDal =departmentDal;
        }

        public List<Department> GetAllDepartment()
        {
            _logger.LogDebug("Inside GetAllDepartment endpoint");
            return _departmentDal.GetAll();
        }

        public Department GetDepartmentById(int id)
        {
            return _departmentDal.Get(x => x.Id == id);
        }

        public void UpdateDepartment(Department department)
        {
            _departmentDal.Update(department);
        }

        public void AddNewDepartment(Department department)
        {
            _departmentDal.Add(department);
        }
    }
}
