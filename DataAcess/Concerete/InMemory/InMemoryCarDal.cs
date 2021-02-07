using DataAccess.Abstract;
using Entites.Concerete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concerete.InMemory
{
    public class EfCarDal : ICarDal
    {
        List<Car> _Cars;

        public EfCarDal()
        {
            _Cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=2,DailyPrice=10000,Description="Mercedes",ModelYear=2020},
                new Car{CarId=2,BrandId=2,ColorId=3,DailyPrice=5000,Description="Volvo",ModelYear=2005},
                new Car{CarId=3,BrandId=3,ColorId=5,DailyPrice=7000,Description="Audi",ModelYear=2007},
                new Car{CarId=4,BrandId=4,ColorId=1,DailyPrice=250,Description="Tofaş",ModelYear=1999},
                new Car{CarId=5,BrandId=5,ColorId=2,DailyPrice=500,Description="Peougot",ModelYear=2012},



            };
        }

        public void Add(Car car)
        {
            _Cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            carToDelete = _Cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _Cars.Remove(carToDelete);           
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _Cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _Cars.Where(c => c.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = null;
            carToUpdate = _Cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
           
        }
    }
}
