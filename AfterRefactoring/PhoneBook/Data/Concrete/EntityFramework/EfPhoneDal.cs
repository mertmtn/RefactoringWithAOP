using Core.DataAccess.EntityFramework;
using Data.Abstract;
using Entities.Concrete; 

namespace Data.Concrete.EntityFramework
{
    public class EfPhoneDal : EfGenericRepository<Phone, PhoneBookDbContext>, IPhoneDal
    {

    }
}
