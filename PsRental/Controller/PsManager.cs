using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsRental.Model.Entityy;

namespace PsRental.Controller
{
    public class PsManager
    {
        PsRepository _PsRepository;

        public PsManager()
        {
            _PsRepository = new PsRepository();
        }

        public int AddPs(Ps ps)
        {
            return _PsRepository.AddPs(ps);
        }

        public int DeletePs(Ps ps)
        {
            return _PsRepository.DeletePs(ps);
        }

        internal int DeletePs(User psToDelete)
        {
            throw new NotImplementedException();
        }
        public int UpdatePs(Ps ps)
        {
            return _PsRepository.UpdatePs(ps);
        }

        internal int UpdatePs(User psToUpdate)
        {
            throw new NotImplementedException();
        }
    }

}
