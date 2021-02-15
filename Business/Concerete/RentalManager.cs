using Business.Abstract;
using Business.Constants;
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

        public IResult Rent(Rental rental)
        {
            var CarList = _rentDal.GetAll();
            foreach (var Car in CarList)
            {
                if (Car.ReturnDate==null)
                {
                    return new ErrorResult("Üzgünüm araba kullanımda");
                }
            }
            _rentDal.Add(rental);
            return new SuccessResult(Messages.OperationSuccessful);
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
            return new SuccessDataResult<List<RentalDetailDto>>(_rentDal.GetRentalDetails(), Messages.OperationSuccessful);
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
    }
}
