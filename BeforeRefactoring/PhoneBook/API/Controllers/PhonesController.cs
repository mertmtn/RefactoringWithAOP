using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhonesController : ControllerBase
    {
        private IPhoneService _phoneService;
        public PhonesController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _phoneService.GetAllPhone());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return StatusCode(200, _phoneService.GetPhoneById(id));
        }


        [HttpPost]
        public IActionResult Post(Phone phone)
        {
            _phoneService.AddNewPhone(phone);
            return StatusCode(200);
        }

        [HttpPut]
        public IActionResult Put(Phone phone)
        {
            _phoneService.UpdatePhone(phone);
            return StatusCode(200);
        }
    }
}
 
