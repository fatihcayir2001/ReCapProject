using Core.DataAccess;
using Core.Utilities.Results;
using Entites.Concerete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        
    }
}
