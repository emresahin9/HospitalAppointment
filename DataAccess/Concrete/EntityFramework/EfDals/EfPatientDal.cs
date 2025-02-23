using Core.DataAccess.Concrete.EntityFramework;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework.EfDals
{
    public class EfPatientDal : EfEntityRepositoryBase<Patient, HospitalAppointmentContext>, IPatientDal
    {
    }
}
