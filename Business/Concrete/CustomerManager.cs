using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
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
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult AddCustomer(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.ProductAdded);
            
        }

        public IDataResult<List<Customer>> GetAllCustomer()
        {
            var entities = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(entities, Messages.ProductsListed);

        }

        public IDataResult<Customer> GetOneCustomer(string id)
        {
            var entity = _customerDal.GetOne(c => c.CustomerId == id);
            if (entity is null)
            {
                return new ErrorDataResult<Customer>(entity, Messages.ProductError);

            }
            return new SuccessDataResult<Customer>(entity, Messages.ProductsListed);

        }
    }
}
