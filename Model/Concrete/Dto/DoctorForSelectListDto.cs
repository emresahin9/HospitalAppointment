using Core.Model.Abstract;

namespace Model.Concrete.Dto
{
    public class DoctorForSelectListDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
