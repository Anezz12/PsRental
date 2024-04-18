using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PsRental.Model.Entityy;

namespace PsRental.Controller
{
    public class CustomerManager
    {
        CustomerRepository _CustomerRepository;

        public CustomerManager()
        {
            _CustomerRepository = new CustomerRepository();
        }


        public int AddCustomer(Customer customer)
        {
            return _CustomerRepository.AddCustomer(customer);
        }

        public int DeleteCustomer(Customer customer)
        {
            return _CustomerRepository.DeleteCustomer(customer);
        }

        public int UpdateCustomer(Customer customer)
        {
            return _CustomerRepository.UpdateCustomer(customer);
        }
    }
}
