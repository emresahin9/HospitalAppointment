﻿using Core.Model.Abstract;
using Core.Model.Concrete;

namespace Model.Concrete.Dto
{
    public class PatientDto : IDto
    {
        public PatientDto()
        {
            Appointments = new List<AppointmentDto>();
            Roles = new List<RoleDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
        public List<RoleDto> Roles{ get; set; }
    }
}