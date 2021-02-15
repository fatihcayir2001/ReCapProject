using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concerete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concerete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarProjectContex>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarProjectContex contex = new CarProjectContex())
            {
                var result = from c in contex.Customers
                             join r in contex.Rentals
                             on c.CustomerId equals r.CustomerId
                             join cars in contex.Cars
                             on r.CarId equals cars.CarId
                             join b in contex.Brands
                             on cars.BrandId equals b.BrandId
                             select new RentalDetailDto()
                             {
                                 CarModel = b.BrandName + cars.Description,
                                 CustomerFirstName = c.FirstName,
                                 CustomerLastName = c.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
                             
                             
            }
        }
    }
}
