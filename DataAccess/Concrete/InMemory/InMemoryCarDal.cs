using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {new Car {CarID=1,BrandID=1,ColorID=1,ModelYear=1999,DailyPrice=75000,Descriptions="İyi Bakılmış Emektar"},
                new Car {CarID=2,BrandID=2,ColorID=1,ModelYear=2022,DailyPrice=390000,Descriptions="Son Model Aile Aracı"},
                new Car {CarID=3,BrandID=3,ColorID=2,ModelYear=1968,DailyPrice=500000,Descriptions="Antika Araç"},
                new Car {CarID=4,BrandID=3,ColorID=1,ModelYear=2009,DailyPrice=45000,Descriptions="Çok Kullanılmış Araç"},
                new Car {CarID=5,BrandID=2,ColorID=3,ModelYear=2015,DailyPrice=100000,Descriptions="Az Kullanılmış Araç"}
                };
        }
        
        
        
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carsToDelete = carsToDelete = _cars.SingleOrDefault(c => c.CarID == car.CarID);
            _cars.Remove(carsToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandID == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarID == car.CarID);

            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Descriptions = car.Descriptions;
        }
      

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
