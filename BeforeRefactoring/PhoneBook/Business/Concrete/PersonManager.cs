using Business.Abstract;
using Data.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Logging;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;
        private readonly ILogger<PersonManager> _logger;
        public PersonManager(IPersonDal personDal, ILogger<PersonManager> logger)
        {
            _logger = logger;
            _personDal = personDal;
        }

        public List<Person> GetAllPerson()
        {
            _logger.LogDebug("Inside GetAllPerson endpoint");
            return _personDal.GetAll();
        }

        public void UpdatePerson(Person person)
        {
            _personDal.Update(person);
        }

        public void AddNewPerson(Person person)
        {
            _personDal.Add(person);
        }

        public Person GetPersonById(int personId)
        {
            return _personDal.Get(x=>x.Id==personId);
        }
    }
}
