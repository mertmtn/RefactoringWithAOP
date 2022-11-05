using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPersonService
    {
        public IDataResult<List<Person>> GetAllPerson();
        public IResult UpdatePerson(Person person);
        public IResult AddNewPerson(Person person);
        public IDataResult<Person> GetPersonById(int personId);
    }
}
