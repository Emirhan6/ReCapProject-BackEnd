using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,RecapProjectDatabaseContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapProjectDatabaseContext context = new RecapProjectDatabaseContext())
            {
                var result = from ca in filter is null ? context.Cars : context.Cars.Where(filter)
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             join img in context.CarImages
                             on ca.CarId equals img.CarId
                             select new CarDetailDto
                             {
                                 CarId = ca.CarId,
                                 BrandId = br.BrandId,
                                 BrandName = br.BrandName,
                                 CarName = ca.CarName,
                                 ColorId = co.ColorId,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 Descriptions = ca.Descriptions,
                                 ModelYear = ca.ModelYear,
                                 CarImageDate=img.CarImageDate,
                                 ImagePath=img.ImagePath
                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsById(int carId)
        {
            using (RecapProjectDatabaseContext context = new RecapProjectDatabaseContext())
            {
                var result = (from ca in context.Cars
                              join co in context.Colors on ca.ColorId equals co.ColorId
                              join br in context.Brands on ca.BrandId equals br.BrandId
                              where ca.CarId == carId
                              select new CarDetailDto
                              {
                                  CarId = ca.CarId,
                                  CarName = ca.Descriptions,
                                  BrandId = br.BrandId,
                                  DailyPrice = ca.DailyPrice,
                                  BrandName = br.BrandName,
                                  ColorId = co.ColorId,
                                  ColorName = co.ColorName,
                                  ModelYear = ca.ModelYear
                              }).ToList();
                return result.ToList();
            }
        }
    }
}
