﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);

            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(u => u.Id == id), Messages.CustomerListed);
        }

        public IResult Insert(Customer customer)
        {
            _customerDal.Add(customer);

            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);

            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
