using GameProject.Abstract;
using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GameProject.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerCheckService _customerCheckService;

        public CustomerManager(ICustomerCheckService customerCheckService)
        {
            _customerCheckService = customerCheckService;
        }

        public void Add(Customer customer)
        {
            if (_customerCheckService.CheckIfRealCustomer(customer))
            {
                Console.WriteLine("Add Customer");
            }
            else
            {
                Console.WriteLine("Do Not Add Customer");
            }
        }

        public void Delete(Customer customer)
        {
            Console.WriteLine("Delete Customer");
        }

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            Console.WriteLine("Get Customer");

            return new Customer();
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            Console.WriteLine("Get Customers");

            return new List<Customer>();
        }

        public void Update(Customer customer)
        {
            if (_customerCheckService.CheckIfRealCustomer(customer))
            {
                Console.WriteLine("Update Customer");
            }
            else
            {
                Console.WriteLine("Do Not Update Customer");
            }
        }
    }
}
