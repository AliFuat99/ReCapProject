using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {

            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //carManager.Add(new Car { CarName = "Toyota Supra", DailyPrice = 800, Description = "Uygun fiyatlarla Toyota Supra kiralama" });

            
            {


                
                UserManager userManager = new UserManager(new EfUserDal());

                User user1 = new User { UserID = 1, UserFirstName = "Aaaa", UserLastName = "şssss", UserEmail = "sffsfaas@gmail.com", UserPassword = "asdajksdasd123" };

                userManager.Add(user1);

                var result = userManager.GetUserDetails();
               
                if (result.Success)
                {

                    foreach (var user in result.Data)
                    {
                        System.Console.WriteLine(user.FirstName + " / " + user.LastName + "/" + user.CompanyName + "/" + user.UserId);
                    }


                }
                else
                {
                    System.Console.WriteLine(result.Message);
                }






                //CarManager carManager = new CarManager(new EfCarDal());
                //var result = carManager.GetCarDetails();

                //if (result.Success)
                //{

                //    foreach (var car in result.Data)
                //    {
                //      System.Console.WriteLine(car.CarName + " / " + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
                //    }


                //}
                //else
                //{
                //    System.Console.WriteLine(result.Message);
                //}

            }

        }
    }
}
