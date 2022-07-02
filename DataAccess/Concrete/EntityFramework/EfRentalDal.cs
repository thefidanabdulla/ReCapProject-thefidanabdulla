using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.Id
                             join re in context.Rentals
                             on ca.Id equals re.CarId
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             from u in context.Users
                             join cu in context.Customers
                             on u.Id equals cu.UserId
                             select new RentalDetailDto
                             {
                                 CarId = ca.Id,
                                 BrandId = b.Id,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 ModelName = ca.Description,
                                 RentalId = re.Id,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 CustomerName = u.FirstName,
                                 CustomerLastname = u.LastName

                             };
                return result.ToList();
            }
        }
    }
}