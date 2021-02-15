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
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarProjectContext contex = new CarProjectContext())
            {
                var result = from b in contex.Brands
                             join c in contex.Cars
                             on b.BrandId equals c.BrandId
                             join color in contex.Colors
                             on c.ColorId equals color.ColorId
                             select new CarDetailDto() {Description=c.Description,ColorName=color.ColorName,BrandName=b.BrandName,DailyPrice=c.DailyPrice };
                return result.ToList();
                       
                              
            }

        }
    }
}
