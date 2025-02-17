using AutoMapper;
using Business.Mappers.AutoMapper.AutoMapperProfiles;

namespace Business.Mappers.AutoMapper
{
    internal static class AutoMapperProfileList
    {
        internal static List<Profile> GetAllProfile()
        {

            return new List<Profile>() {
                new AdminDtoProfile(),
                new HospitalDtoProfile(),
                new MedicalSpecialtyDtoProfile(),
                new HospitalMedicalSpecialtiesDtoProfile(),
                new DoctorDtoProfile(),
                new AppointmentDtoProfile()
                
            };

        }
    }
}

