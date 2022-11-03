using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPersonService
    {
        public List<Person> GetAllPerson();
        public void UpdatePerson(Person person);
        public void AddNewPerson(Person person);
        public Person GetPersonById(int personId);
    }
}
