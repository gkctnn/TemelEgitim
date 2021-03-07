using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        private IResult CheckUnReturnedCarByCarId(int carId)
        {
            Rental carWhichChecked = _rentalDal.Get(u => u.CarId == carId && !u.ReturnDate.HasValue);

            if (carWhichChecked != null)
            {
                return new ErrorResult(Messages.UnReturnedCar);
            }

            return new SuccessResult(Messages.ReturnedCar);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(u => u.Id == id), Messages.RentalListed);
        }

        public IResult Insert(Rental rental)
        {
            var carCheck = CheckUnReturnedCarByCarId(rental.CarId);

            if (carCheck.Success)
            {
                _rentalDal.Add(rental);

                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {
                return new ErrorResult(carCheck.Message);
            }
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);

            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
