using Business.Abstract;
using Business.ValidatonRules.FluentValidation;
using Core.Utilities.Results;
using Core.Utilities.Results.Error;
using Core.Utilities.Results.Success;
using Data.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Logging; 

namespace Business.Concrete
{
    public class PhoneManager : IPhoneService
    {
        private IPhoneDal _phoneDal;
        private readonly ILogger<PhoneManager> _logger;
        public PhoneManager(IPhoneDal phoneDal, ILogger<PhoneManager> logger)
        {
            _logger = logger;
            _phoneDal = phoneDal;
        } 

        public IDataResult<List<Phone>> GetAllPhone()
        {
            _logger.LogDebug("Inside GetAllPhone endpoint");
            var result= _phoneDal.GetAll();
            return new SuccessDataResult<List<Phone>>(result);
        }

        public IResult UpdatePhone(Phone phone)
        {
            try
            {
                var validator = new PhoneValidator();
                var validationResult = validator.Validate(phone);
                if (!validationResult.IsValid)
                {
                    List<string> errorList = new();
                    foreach (var error in validationResult.Errors)
                    {
                        errorList.Add(error.ErrorMessage);
                    }
                    return new ErrorDataResult<List<string>>(errorList, "Check your fields.");
                }
                _phoneDal.Update(phone);
                return new SuccessResult("Phone updated succesfully");
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message, ex.StackTrace);
                return new ErrorResult("Error occurred during operation, please try again later.");
            }
        }

        public IResult AddNewPhone(Phone phone)
        {
            try
            {
                var validator = new PhoneValidator();
                var validationResult = validator.Validate(phone);
                if (!validationResult.IsValid)
                {
                    List<string> errorList = new();
                    foreach (var error in validationResult.Errors)
                    {
                        errorList.Add(error.ErrorMessage);
                    }
                    return new ErrorDataResult<List<string>>(errorList, "Check your fields.");
                }
                _phoneDal.Add(phone);
                return new SuccessResult("Phone added succesfully");
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message, ex.StackTrace);
                return new ErrorResult("Error occurred during operation, please try again later.");
            }            
        }

        public IDataResult<Phone> GetPhoneById(int phoneId)
        {
            var result = _phoneDal.Get(x => x.Id == phoneId);
            return new SuccessDataResult<Phone>(result); 
        }
    }
}
