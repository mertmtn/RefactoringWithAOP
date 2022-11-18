using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneTypesController : ControllerBase
    {
        private IPhoneTypeService _phoneTypeService;
        public PhoneTypesController(IPhoneTypeService phoneTypeService)
        {
            _phoneTypeService = phoneTypeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _phoneTypeService.GetAllPhoneType()); 
        }
    }
}
 
