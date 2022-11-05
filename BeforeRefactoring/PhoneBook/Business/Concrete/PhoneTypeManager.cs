using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
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

        public IDataResult<List<PhoneType>> GetAllPhoneType()
        {
            _logger.LogDebug("Inside GetAllPhoneType endpoint");
            var result = _phoneTypeDal.GetAll();
            return new SuccessDataResult<List<PhoneType>>(result);
        }
    }
}
