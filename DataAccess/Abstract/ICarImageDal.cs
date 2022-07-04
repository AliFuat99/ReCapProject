using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICarImageDal:IEntityRepositery<CarImage>
    {
        List<CarImageDetailDto> GetCarImageList(Expression<Func<CarImageDetailDto, bool>> filter = null);
    }
}
