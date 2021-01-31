using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Cars> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Cars>
            {
                new Cars{Id=1,CarName="Hyundai", BrandId=1,ColorId=1,DailyPrice=300,ModelYear=2015,Description="Araba"},
                new Cars{Id=2,CarName="BMW",BrandId=2,ColorId=2,DailyPrice=400,ModelYear=2010,Description="Araba 2"},
                new Cars{Id=3,CarName="Mercedes",BrandId=3,ColorId=3,DailyPrice=250,ModelYear=2016,Description="Araba 3"}
            };
        }

        public void Add(Cars cars)
        {
            _cars.Add(cars);
        }


        public void Delete(Cars cars)
        {
            Cars carsToDelete = _cars.SingleOrDefault(p => p.Id == cars.Id);
            _cars.Remove(carsToDelete);
        }

        public List<Cars> GetAll()
        {
            return _cars;
        }

        public List<Cars> GetById(int carId)
        {
            return _cars.Where(a => a.Id == carId).ToList();
        }

        public void Update(Cars cars)
        {

            Cars carsToUpdate = _cars.SingleOrDefault(p => p.Id == cars.Id);
            carsToUpdate.BrandId = cars.BrandId;
            carsToUpdate.ColorId = cars.ColorId;
            carsToUpdate.DailyPrice = cars.DailyPrice;
            carsToUpdate.ModelYear = cars.ModelYear;
            carsToUpdate.Description = cars.Description;
        }
    }
}
