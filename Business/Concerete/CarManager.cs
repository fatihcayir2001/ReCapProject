﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concerete;
using Entites.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concerete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheRemoveAspect("ICarService.Get")]
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
        [CacheRemoveAspect("ICarService.Get")]

        public IResult Delete(Car car)
        {
            if (car.ModelYear < 2000)
            {
                return new ErrorResult(Messages.CarModelInvalid);
            }
            _carDal.Add(car);
            return new Result(true, Messages.CarDeleted);

        }
        
        [CacheAspect]
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);

        }

        [CacheAspect]
        [SecuredOperation("admin")]
        public IDataResult<Car> GetByCarId(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails()) ;
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice>10)
            {
                throw new Exception();
            }

            Add(car);
            return null;
        }

        public IDataResult<List<CarDetailDto>> GetByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == id));
        }

        public IDataResult<List<CarDetailDto>> GetByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId==id));

        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c =>
                c.BrandId == brandId && c.ColorId == colorId));
        }


        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]//IProductService.Get key li tüm cachi sil
        public IResult Update(Car car)
        {
            if (car.ModelYear < 2000)
            {
                return new ErrorResult(Messages.CarUpdated);
            }
            _carDal.Add(car);
            return new Result(true, Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(x => x.CarId == carId));
        }

        
    }
}
