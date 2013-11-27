using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02EndToEndWebApp_done.Model
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(int customerId);

        void DeleteCustomer(Customer cust);

        void UpdateCustomer(Customer cust);

        void AddCustomer(Customer cust);

        int GetCustomerCount();
    }
}