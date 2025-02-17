using Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.EfDals;

namespace DataAccess.DependencyResolvers.Autofac
{
    public class AutofacDataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfAdminDal>().As<IAdminDal>().SingleInstance();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>().SingleInstance();
            builder.RegisterType<EfAdminRoleDal>().As<IAdminRoleDal>().SingleInstance();
            builder.RegisterType<EfHospitalDal>().As<IHospitalDal>().SingleInstance();
            builder.RegisterType<EfMedicalSpecialtyDal>().As<IMedicalSpecialtyDal>().SingleInstance();
            builder.RegisterType<EfHospitalMedicalSpecialtiesDal>().As<IHospitalMedicalSpecialtiesDal>().SingleInstance();
            builder.RegisterType<EfDoctorDal>().As<IDoctorDal>().SingleInstance();
            builder.RegisterType<EfAppointmentDal>().As<IAppointmentDal>().SingleInstance();
        }
    }
}
