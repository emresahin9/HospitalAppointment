using Core.DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IAppointmentDal : IEntityRepository<Appointment>
    {
    }
}
