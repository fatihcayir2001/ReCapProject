using Entites.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void AddToDb(Car car);
        void UpdateToDb(Car car);
        void DeleteFromDb(Car car);
        List<Car> GetById(int carId);
    }
}
