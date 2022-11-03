using Business.Abstract;
using Data.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Logging; 

namespace Business.Concrete
{
    public class PhoneTypeManager : IPhoneTypeService
    {
        private IPhoneTypeDal _phoneTypeDal;
        private readonly ILogger<PhoneTypeManager> _logger;
        public PhoneTypeManager(IPhoneTypeDal phoneTypeDal, ILogger<PhoneTypeManager> logger)
        {
            _logger = logger;
            _phoneTypeDal = phoneTypeDal;
        } 

        public List<PhoneType> GetAllPhoneType()
        {
            _logger.LogDebug("Inside GetAllPhoneType endpoint");
            return _phoneTypeDal.GetAll();
        }
    }
}
