

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concerete;
using Entites.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concerete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers
                             on r.CustomerId equals c.CustomerId
                             join cars in context.Cars
                             on r.CarId equals cars.CarId
                             join b in context.Brands
                             on cars.BrandId equals b.BrandId
                             join u in context.Users
                             on c.UserId equals u.Id
                             
                             select new RentalDetailDto()
                             {
                                 CarModel = b.BrandName,
                                 CustomerFirstName=u.FirstName,
                                 CustomerLastName=u.LastName,
                                 RentalId=r.Id,
                                 RentDate=r.RentDate,
                                 ReturnDate=r.ReturnDate
                             };
                return result.ToList();
                             
                             
            }
        }
    }
}
