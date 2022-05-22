 using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Color color1 = new Color();
            color1.ColorId = 1;
            color1.ColorName = "Black";

            colorManager.Add(color1);

            Brand brand1 = new Brand();
            brand1.BrandId = 1;
            brand1.BrandName = "BMW";

            brandManager.Add(brand1);

            Car car1 = new Car();
            car1.Id = 1;
            car1.BrandId = 1;
            car1.ColorId = 1;
            car1.DailyPrice = 5000;
            car1.ModelYear = 2020;
            car1.Description = "Good Car";

            carManager.Add(car1);


            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear);
            }
        }
    }

    
}
