using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerInfo.Model;
using CustomerInfo.Repository;

namespace CustomerInfo.Manager
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }

        public List<District> ComboDistricts()
        {
            return _customerRepository.ComboDistricts();
        }

        public List<ViewCustomer> Display()
        {
            return _customerRepository.Display();
        }

        public bool IsCodeUniqe(String code)
        {
            return _customerRepository.IsCodeUniqe(code);
        }

        public bool IsContactUniqe(String contact)
        {
            return _customerRepository.IsContactUniqe(contact);
        }

        public List<Customer> SearchCustomerByCode(Customer customer)
        {
            return _customerRepository.SearchCustomerByCode(customer);
        }
    }
}
