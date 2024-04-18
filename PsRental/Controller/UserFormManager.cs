using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsRental.Model.Entityy;

namespace PsRental.Controller
{
    public class UserFormManager
    {
        UserFormRepositroy _UserFormRepository;



        public UserFormManager()
        {
            _UserFormRepository = new UserFormRepositroy();
        }

        public int AddUser(User user)
        {
            return _UserFormRepository.AddUser(user);
        }

        public int DeleteUser(User user)
        {
            return _UserFormRepository.DeleteUser(user);
        }

        public int UpdateUser(User user)
        {
            return _UserFormRepository.UpdateUser(user);
        }
    }

 
}
