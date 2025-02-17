using Core.Entity.Concrete;
using Core.Model.Concrete;
using Model.Concrete.Dto;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IAdminService
    {
        string Login(LoginDto loginDto);
        AdminDto Get(Expression<Func<Admin, bool>> filter);
    }
}
