using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI2
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllCars();

        }

        private static void GetAllCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.BrandId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
