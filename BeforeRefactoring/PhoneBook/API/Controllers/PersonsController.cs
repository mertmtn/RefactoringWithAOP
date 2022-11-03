using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private IPersonService _personService;
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _personService.GetAllPerson();
            return StatusCode(200, result);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var result = _personService.GetPersonById(id);
            return StatusCode(200, result);
        }

        [HttpPost]
        public IActionResult Post(Person person)
        {
            _personService.AddNewPerson(person);
            return StatusCode(200);
        }

        [HttpPut]
        public IActionResult Put(Person person)
        {
            _personService.UpdatePerson(person);
            return StatusCode(200);
        } 
    }
}
 
