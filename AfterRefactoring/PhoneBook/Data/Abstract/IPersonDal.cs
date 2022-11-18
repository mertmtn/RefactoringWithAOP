using Core.DataAccess;
using Entities.Concrete;

namespace Data.Abstract
{
    public interface IPersonDal : IEntityRepository<Person>
    {
    }
}
