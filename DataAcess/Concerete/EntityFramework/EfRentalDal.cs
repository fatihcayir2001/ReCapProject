

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concerete;
using Entites.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concerete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarProjectContex>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarProjectContex contex = new CarProjectContex())
            {
                var result = from r in contex.Rentals
                             join c in contex.Customers
                             on r.CustomerId equals c.CustomerId
                             join cars in contex.Cars
                             on r.CarId equals cars.CarId
                             join b in contex.Brands
                             on cars.BrandId equals b.BrandId
                             select new RentalDetailDto()
                             {
                                 CarModel = b.BrandName,
                                 CustomerFirstName=c.FirstName,
                                 CustomerLastName=c.LastName,
                                 RentalId=r.Id,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate
                             };
                return result.ToList();
                             
                             
            }
        }
    }
}
