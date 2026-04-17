using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public void AddCustomer(Customer customer)
        {
            _customerDal.Add(customer);
            
        }

        public List<Customer> GetAllCustomer()
        {
            return _customerDal.GetAll();

        }

        public Customer GetOneCustomer(string id)
        {
            return _customerDal.GetOne(c => c.CustomerId == id);

        }
    }
}
