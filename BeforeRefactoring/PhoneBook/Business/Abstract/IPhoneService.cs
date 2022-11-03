using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPhoneService
    {
        public List<Phone> GetAllPhone(); 
        public void UpdatePhone(Phone phone);
        public void AddNewPhone(Phone phone);
        public Phone GetPhoneById(int phoneId);
    }
}
