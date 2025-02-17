using Core.DataAccess.Abstract;
using Core.Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IAdminDal : IEntityRepository<Admin>
    {
    }
}
