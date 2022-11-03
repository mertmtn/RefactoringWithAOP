using Core.DataAccess.EntityFramework;
using Data.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EntityFramework
{
    public class EfPersonDal : EfGenericRepository<Person, PhoneBookDbContext>, IPersonDal
    {
    }
}
