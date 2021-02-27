using Core.DataAccess;
using Entites.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarImageDal : IEntityRepository<CarImage>
    {
        public bool IsExist(int id);
    }
}
