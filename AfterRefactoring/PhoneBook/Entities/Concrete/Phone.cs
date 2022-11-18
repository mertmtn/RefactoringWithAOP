using Entities.Abstract;

namespace Entities.Concrete
{
    public class Phone: IEntity
    {
        public int Id { get; set; }
        public int PhoneTypeId { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsVisible { get; set; }
        public int PersonId { get; set; }
    }
}
