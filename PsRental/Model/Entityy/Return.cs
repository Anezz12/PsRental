using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsRental.Model.Entityy
{
    public class Return
    {
        public string ReturnId { get; set; }
        public string PsId { get; set; }
        public string CustName { get; set; }
        public string ReturnDate { get; set; }
        public string Fine { get; set; }
        public string Delay { get; set; }
    }
}
