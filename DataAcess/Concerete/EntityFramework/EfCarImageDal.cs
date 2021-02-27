using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concerete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, CarProjectContext>, ICarImageDal
    {
        public bool IsExist(int id)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                return context.CarImages.Any(c => c.Id == id);
            }
        }
    }
}
