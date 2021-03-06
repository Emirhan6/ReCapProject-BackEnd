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

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate==null)
            {
                return new ErrorResult(Messages.UndeliveredCar);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.CarRented);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.CarRentDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.CarsToBeRentedListed);
            }
        }

        public IDataResult<Rental> GetByCarId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.CarId == id));
        }

        public IDataResult<Rental> GetByCustomerId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.CustomerId == id));
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId ==id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentUpdated);
        }
    }
}
