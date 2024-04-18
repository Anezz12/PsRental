using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsRental.Model.Entityy;

namespace PsRental.Controller
{
    public class RentalFormManager
    {
        RentalRepository _RentalRepository;

        public RentalFormManager()
        {
            _RentalRepository = new RentalRepository();
        }

        public int AddRental(Rental rental)
        {
            return _RentalRepository.AddRental(rental);
        }

        public int DeleteRental(Rental rental)
        {
            return _RentalRepository.DeleteRental(rental);
        }

        public int UpdateRental(Rental rental)
        {
            return _RentalRepository.UpdateRental(rental);
        }
    }
}
