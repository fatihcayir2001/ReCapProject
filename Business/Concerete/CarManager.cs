using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concerete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public void AddToDb(Car car)
        {
            _carDal.Add(car);
        }


        public void DeleteFromDb(Car car)
        {
            _carDal.Delete(car);
        }


        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetById(int carId)
        {
            return _carDal.GetById(carId);
        }

        public void UpdateToDb(Car car)
        {
            _carDal.Update(car);
        }

    }
}
