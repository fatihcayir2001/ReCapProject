﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concerete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concerete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentDal;

        public RentalManager(IRentalDal rentDal)
        {
            _rentDal = rentDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Rent(Rental rental)
        {
            //var carToNotRent = _rentDal.Get(c => c.CarId == rental.CarId && (c.ReturnDate ==null || c.ReturnDate>DateTime.Now));

            //if (carToNotRent != null)
            //{
            //    return new ErrorResult(Messages.OperationFailed);
            //}
            //_rentDal.Add(rental);
            //return new SuccessResult(Messages.OperationSuccessful);
            _rentDal.Add(rental);
            return new Result(true,Messages.OperationSuccessful);
        }

        public IResult Delete(Rental rental)
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _rentDal.Delete(rental);
            return new SuccessResult(Messages.OperationSuccessful);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            var result = _rentDal.GetRentalDetails();
            return new SuccessDataResult<List<RentalDetailDto>>(result, Messages.OperationSuccessful);
        }

        public IResult Update(Rental rental)
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _rentDal.Update(rental);
            return new SuccessResult(Messages.OperationSuccessful);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentDal.Get(r => r.Id == id));
        }


        public IResult IsRentable(Rental rental)
        {
            var result = _rentDal.GetAll();
            if (result.Where(r => r.CarId == rental.CarId
                                  && r.ReturnDate >= rental.RentDate
                                  && r.RentDate <= rental.ReturnDate).Any())
                return new ErrorResult(Messages.RentalInValid);
            return new SuccessResult(Messages.CarIsRentable);
        }

    }
}
