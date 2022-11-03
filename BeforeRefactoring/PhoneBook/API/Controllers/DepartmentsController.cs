using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _departmentService.GetAllDepartment();
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _departmentService.GetDepartmentById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Post(Department department)
        {
            var result = _departmentService.AddNewDepartment(department);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Put(Department department)
        {
            var result = _departmentService.UpdateDepartment(department);
            return StatusCode(result.Success ? 200 : 400,result);
        }
    }
}

