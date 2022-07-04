using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal:EfEntityRepositoryBase<CarImage, Context>, ICarImageDal
    {
        public List<CarImageDetailDto> GetCarImageList(Expression<Func<CarImageDetailDto, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                var result = from ci in context.CarImages
                             join ca in context.Cars on ci.ImageCarID equals ca.CarID
                             select new CarImageDetailDto()
                             {
                                 CarId = ca.CarID,
                                 ImagePath = ci.ImagePath
                             };
                return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
            };
        }
    }
}
