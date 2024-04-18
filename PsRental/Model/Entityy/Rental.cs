using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsRental.Model.Entityy
{
    public class Rental
    {
        public string RentId { get; set; }
        public string PsId { get; set; }

        public string CustName { get; set; }

        public string RentDate { get; set; }

        public string RentFee { get; set; }

        public string ReturnDate { get; set; }
    }
}
