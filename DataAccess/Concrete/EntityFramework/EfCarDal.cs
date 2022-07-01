using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,Context>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (Context context = new Context())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandID equals b.BrandID
                             join cr in context.Colors on c.ColorID equals cr.ColorID
                             select new CarDetailDto 
                             {
                             CarName = c.CarName,
                             BrandName = b.BrandName,
                             ColorName = cr.ColorName,
                             DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
