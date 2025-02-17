using Core.DataAccess.Concrete.EntityFramework;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework.EfDals
{
    public class EfAdminRoleDal : EfEntityRepositoryBase<AdminRole, HospitalAppointmentContext>, IAdminRoleDal
    {
    }
}
