using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, Context>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDto()
        {
            using (Context context = new Context())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarID equals c.CarID
                             join u in context.Users
                             on r.CarID equals u.UserID
                             select new RentalDetailDto { CarId = c.CarID, CustomerId = u.UserID, RentalId = u.UserID, DailyPrice = c.DailyPrice, Description = c.Descriptions, RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return result.ToList();

            }
        }
    }
}
