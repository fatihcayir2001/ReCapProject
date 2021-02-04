using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //var result = from c in Cars
            //             join b in Brands
                         //on b.BrandId equals c.BrandId;
            
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void UpdateToDb(Car car)
        {
            _carDal.Update(car);
        }

    }
}
