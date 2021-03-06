using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concerete;
using Entites.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;

namespace Business.Concerete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        
        [SecuredOperation("admin,car.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (car.ModelYear<2000)
            {
                return new ErrorResult(Messages.CarModelInvalid);
            }
            _carDal.Add(car);
            return new Result(true, Messages.CarAdded);
            
        }

        public IResult Delete(Car car)
        {
            if (car.ModelYear < 2000)
            {
                return new ErrorResult(Messages.CarModelInvalid);
            }
            _carDal.Add(car);
            return new Result(true, Messages.CarDeleted);

        }
        
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);

        }
        [SecuredOperation("admin")]
        public IDataResult<Car> GetByCarId(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails()) ;
        }

        public IResult Update(Car car)
        {
            if (car.ModelYear < 2000)
            {
                return new ErrorResult(Messages.CarUpdated);
            }
            _carDal.Add(car);
            return new Result(true, Messages.CarUpdated);
        }
    }
}
