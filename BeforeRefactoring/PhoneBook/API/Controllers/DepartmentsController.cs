using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            return StatusCode(200, _departmentService.GetAllDepartment());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return StatusCode(200, _departmentService.GetDepartmentById(id));
        }


        [HttpPost]
        public IActionResult Post(Department department)
        {
            _departmentService.AddNewDepartment(department);
            return StatusCode(200);
        }

        [HttpPut]
        public IActionResult Put(Department department)
        {
            _departmentService.UpdateDepartment(department);
            return StatusCode(200);
        }
    }
}
 
