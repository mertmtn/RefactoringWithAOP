using Core.DataAccess;
using Entities.Concrete;

namespace Data.Abstract
{
    public interface IDepartmentDal : IEntityRepository<Department>
    {
    }
}
