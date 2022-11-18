using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPhoneService
    {
        public IDataResult<List<Phone>> GetAllPhone(); 
        public IResult UpdatePhone(Phone phone);
        public IResult AddNewPhone(Phone phone);
        public IDataResult<Phone> GetPhoneById(int phoneId);
    }
}
