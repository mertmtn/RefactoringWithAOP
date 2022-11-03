using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
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
            _departmentDal = departmentDal;
        }

        public IDataResult<List<Department>> GetAllDepartment()
        {
            _logger.LogDebug("Inside GetAllDepartment endpoint");
            return new SuccessDataResult<List<Department>>(_departmentDal.GetAll());
        }

        public IDataResult<Department> GetDepartmentById(int id)
        {
            return new SuccessDataResult<Department>(_departmentDal.Get(x => x.Id == id));
        }

        public IResult UpdateDepartment(Department department)
        {
            _departmentDal.Update(department);
            return new SuccessResult("Update Department Success");
        }

        public IResult AddNewDepartment(Department department)
        {
            _departmentDal.Add(department);
            return new SuccessResult("Add Department Success");
        }
    }
}
