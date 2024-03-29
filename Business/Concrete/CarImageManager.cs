﻿using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Helpers.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.ImageCarID));
            if (result != null)
            {
                return result;
            }

            var fileResult = _fileHelper.Upload(file, StaticUploadRoot.ImagePath);
            if (fileResult.Success)
            {
                var fileName = fileResult.Message;
                var filePath = StaticUploadRoot.ImagePath + fileName;
                carImage.ImagePath = filePath;
                carImage.CarImageDate = DateTime.Now;

                _carImageDal.Add(carImage);
                return new SuccessResult();
            }
            return new ErrorResult("Yükleme başarısız");

        }

        public IResult Delete(CarImage carImage)
        {
            var dbObject = _carImageDal.Get(c => c.ImageCarID == carImage.ImageCarID && c.ImagePath == carImage.ImagePath);
            if (dbObject != null)
            {
                carImage = dbObject;
                IResult result = _fileHelper.Delete(carImage.ImagePath);
                if (result.Success)
                {
                    _carImageDal.Delete(carImage);
                    return result;
                }
                return result;
            }
            return new ErrorResult();
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var dbObject = _carImageDal.Get(c => c.ImageCarID == carImage.ImageCarID && c.ImagePath == carImage.ImagePath);
            if (dbObject != null)
            {
                carImage = dbObject;
                IResult result = _fileHelper.Update(file, carImage.ImagePath, StaticUploadRoot.ImagePath);
                if (result.Success)
                {
                    carImage.ImagePath = StaticUploadRoot.ImagePath + result.Message;
                    _carImageDal.Update(carImage);
                    return result;
                }
            }
            return new ErrorResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            var result = BusinessRules.Run(CheckIfAnyImageExists(id));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(id));
            }
            else
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.ImageCarID == id));
            }
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.CarImageID == id));
        }

        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(p => p.ImageCarID == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult("Maksimum fotoğraf sınırına ulaşıldı");
            }
            return new SuccessResult();
        }

        private IResult CheckIfAnyImageExists(int id)
        {
            var result = _carImageDal.GetAll(c => c.ImageCarID == id);
            if (result.Any())
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private List<CarImage> GetDefaultImage(int id)
        {
            List<CarImage> defaultImage = new List<CarImage>();
            defaultImage.Add(new CarImage
            {
                ImageCarID = id,
                CarImageDate = DateTime.Now,
                ImagePath = StaticImageRoot.ImagePath + "logo.png"
            });
            return defaultImage;
        }

        public IDataResult<List<CarImageDetailDto>> GetCarImageList(int id)
        {
            return new SuccessDataResult<List<CarImageDetailDto>>(_carImageDal.GetCarImageList(c => c.CarId == id));
        }
    }
}
