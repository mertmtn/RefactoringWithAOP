using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPhoneTypeService
    {
        public IDataResult<List<PhoneType>> GetAllPhoneType();
    }
}
