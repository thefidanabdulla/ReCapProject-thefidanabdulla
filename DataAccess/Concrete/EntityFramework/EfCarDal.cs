using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id

                             select new CarDetailDto
                             {  
                                Id = c.Id,
                                ColorId = co.Id,
                                BrandId = b.Id,
                                ColorName = co.ColorName,
                                BrandName = b.BrandName, 
                                Description = c.Description, 
                                ModelYear = c.ModelYear, 
                                DailyPrice = c.DailyPrice,
                                ImagePath = (from m in context.CarImages where m.CarId == c.Id select m.ImagePath).FirstOrDefault()
                             };

                 return filter == null
               ? result.ToList()
               : result.Where(filter).ToList();
            }
        }
    }
}
