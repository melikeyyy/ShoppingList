using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
//using ECommerceApplication.Models;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetList()
        {
            return _userDal.List();
        }

        public void UserAdd(User user)
        {
            throw new NotImplementedException();
        }

        public void UserDelete(User user)
        {
            throw new NotImplementedException();
        }

        public void UserUpdate(User user)
        {
            throw new NotImplementedException();
        }
    }
}
