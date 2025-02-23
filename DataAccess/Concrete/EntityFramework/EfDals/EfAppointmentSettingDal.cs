﻿using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework.EfDals
{
    public class EfAppointmentSettingDal : EfEntityRepositoryBase<AppointmentSetting, HospitalAppointmentContext>, IAppointmentSettingDal
    {
    }
}
