using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            
            if (rental.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalInvalid);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);

        }
        public IResult Delete(Rental rental)
        {
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);

            }

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.CustomerListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailDto());
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
