using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concerete;
using Entites.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concerete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from b in context.Brands
                             join c in context.Cars
                             on b.BrandId equals c.BrandId
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             
                             select new CarDetailDto() 
                                 {Description=c.Description,ColorName=color.ColorName,BrandName=b.BrandName,DailyPrice=c.DailyPrice,BrandId = b.BrandId,
                                     ColorId = color.ColorId,CarId = c.CarId,ModelYear = c.ModelYear,ImagePath =
                                         (from i in context.CarImages where i.CarId == c.CarId select i.ImagePath).ToList(),
                                 };
                return filter == null ? result.ToList() :
                    result.Where(filter).ToList();


            }

        }

        
    }
}
