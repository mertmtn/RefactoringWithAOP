using Core.DataAccess.EntityFramework;
using Data.Abstract;
using Entities.Concrete; 

namespace Data.Concrete.EntityFramework
{
    public class EfDepartmentDal : EfGenericRepository<Department, PhoneBookDbContext>, IDepartmentDal
    {

    }
}
