using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopLayer.Repository;
namespace CoffeeShopLayer.Bill
{
    
    class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool AddInfo(string name, string contact, string address, string item, int quantity)
        {
            return _customerRepository.AddInfo(name, contact, address, item, quantity);
        
        }
        public DataTable ShowCustomer()
        {
            return _customerRepository.ShowCustomer();
        }
        public bool UpdateCustomer(string name, string contact, string address, string item, int quantity, int id)
        {
            return _customerRepository.UpdateCustomer(name, contact, address, item, quantity,id);
        }
        public DataTable SearchCustomer(string searchName)
        {
            return _customerRepository.SearchCustomer(searchName);
        }
        public bool DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }
    }
}
