using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailById(int id);
        IDataResult<Car> GetCarById(int carId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult< List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailByColorAndByBrand(int colorId, int brandId);
        IResult AddTransactionalTest(Car car);
    }
}
