using Core.Utilities.Results;
using Entites.Concerete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult Rent(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<Rental> GetById(int id);
    }
}
