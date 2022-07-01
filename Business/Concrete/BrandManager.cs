using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

         BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 0 )
            {
                
                return new ErrorResult(Messages.BrandAdded);
            }
            else
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.CarAdded);
            }
        }

        public IResult Delete(Brand brand)
        {
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(Messages.BrandListed);
        }

        public IResult Update(Brand brand)
        {
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
