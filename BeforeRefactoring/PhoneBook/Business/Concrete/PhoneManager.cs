using Business.Abstract;
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

        public List<Phone> GetAllPhone()
        {
            _logger.LogDebug("Inside GetAllPhone endpoint");
            return _phoneDal.GetAll();
        }

        public void UpdatePhone(Phone phone)
        {
            _phoneDal.Update(phone);
        }

        public void AddNewPhone(Phone phone)
        {
            _phoneDal.Add(phone);
        }

        public Phone GetPhoneById(int phoneId)
        {
            return _phoneDal.Get(x=>x.Id== phoneId);
        }
    }
}
