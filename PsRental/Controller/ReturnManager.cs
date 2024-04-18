
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsRental.Model.Entityy;

namespace PsRental.Controller
{
    public class ReturnManager
    {
        ReturnRepository _returnRepository;

        public ReturnManager()
        {
            _returnRepository = new ReturnRepository();
        }

        public int AddReturn(Return Return)
        {
            return _returnRepository.AddReturn(Return);
        }

        public int DeleteReturn(Return Return)
        {
            return _returnRepository.DeleteReturn(Return);
        }
 
    }
}
