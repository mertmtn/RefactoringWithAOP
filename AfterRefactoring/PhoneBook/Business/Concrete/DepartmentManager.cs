using Business.Abstract;
using Business.ValidatonRules.FluentValidation;
using Core.Aspects.Autofac.Caching.Microsoft;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Error;
using Core.Utilities.Results.Success;
using Data.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IDepartmentDal _departmentDal;
        private readonly ILogger<DepartmentManager> _logger;
        public DepartmentManager(IDepartmentDal departmentDal, ILogger<DepartmentManager> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _departmentDal = departmentDal; 
            _memoryCache = memoryCache;
        }

        [LoggingAspect()]
        [CachingAspect(2)]
        public IDataResult<List<Department>> GetAllDepartment()
        {
            var departmentList = _departmentDal.GetAll();            
            return new SuccessDataResult<List<Department>>(departmentList, 200);
        }

        public IDataResult<Department> GetDepartmentById(int id)
        {
            return new SuccessDataResult<Department>(_departmentDal.Get(x => x.Id == id),200);
        }

        [LoggingAspect()]
        [ValidationAspect(typeof(DepartmentValidator))]
        [ExceptionAspect(typeof(Result))]
        public IResult UpdateDepartment(Department department)
        {            
            _departmentDal.Update(department);
            return new SuccessResult("Update Department Success",200);
        }

        [LoggingAspect()]
        [ValidationAspect(typeof(DepartmentValidator))]
        public IResult AddNewDepartment(Department department)
        {           
            _departmentDal.Add(department);
            return new SuccessResult("Add Department Success", 200);
        }
    }
}
