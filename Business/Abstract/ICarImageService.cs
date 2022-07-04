using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICarImageService
   {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetByCarId(int id);
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImageDetailDto>> GetCarImageList(int id);
        
        IResult Add(CarImage carImage, IFormFile file);
        IResult Update(CarImage carImage, IFormFile file);
        IResult Delete(CarImage carImage);
    }
}
