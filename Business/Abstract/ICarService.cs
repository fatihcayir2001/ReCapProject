using Core.Utilities.Results;
using Entites.Concerete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails();

    }
}
