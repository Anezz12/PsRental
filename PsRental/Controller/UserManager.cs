using PsRental.Model.Entityy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsRental.Controller
{
    public class UserManager
    {
        UserRepository _userRepository;

        public UserManager()
        {
            _userRepository = new UserRepository();
        }

        public int Login(User user)
        {
            return _userRepository.LogIn(user);
        }
    }
}
