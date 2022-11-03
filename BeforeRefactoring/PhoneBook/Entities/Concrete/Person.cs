using Entities.Abstract;

namespace Entities.Concrete
{
    public class Person: IEntity
    {
        public int Id { get; set; } 

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Address { get; set; }

        public int CityId { get; set; }        

        public string Email { get; set; }
       
        public int DepartmentId { get; set; }
    }
}
