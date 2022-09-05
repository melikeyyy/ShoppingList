using Business.Abstract;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RegisterManager : IRegisterService
    {
        IUserDal _userDal;

        public RegisterManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void UserAdd(User user)
        {
            _userDal.Insert(user);
        }
    }
}
