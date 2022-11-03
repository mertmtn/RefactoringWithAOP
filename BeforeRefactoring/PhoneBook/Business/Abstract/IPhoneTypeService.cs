using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPhoneTypeService
    {
        public List<PhoneType> GetAllPhoneType();
    }
}
