using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework.EfDals
{
    public class EfDoctorDal : EfEntityRepositoryBase<Doctor, HospitalAppointmentContext>, IDoctorDal
    {
    }
}
