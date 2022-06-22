﻿using Core.DataAccess.EntityFramework;
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
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailDto 
                             {  Id = c.Id, 
                                ColorName = c.ColorId,
                                BrandName = b.BrandName, 
                                Description = c.Description, 
                                ModelYear = c.ModelYear, 
                                DailyPrice = c.DailyPrice 
                             };
                return result.ToList();
            }
        }
    }
}
