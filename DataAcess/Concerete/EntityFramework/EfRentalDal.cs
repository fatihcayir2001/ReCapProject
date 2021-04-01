using System;
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
                    join c in context.Cars 
                        on r.CarId equals c.CarId
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join cu in context.Customers
                        on r.CustomerId equals cu.CustomerId
                    join u in context.Users
                        on cu.UserId equals u.Id
                    select new RentalDetailDto
                    {
                        CarModel = c.Description,
                        CustomerFirstName = u.FirstName,
                        CustomerLastName = u.LastName,
                        RentDate = r.RentDate,
                        RentalId = r.Id,
                        ReturnDate = r.ReturnDate,
                        CarId = c.CarId,
                        CustomerId = cu.CustomerId,
                        BrandId = b.BrandId,
                        BrandName = b.BrandName
                    };

                return result.ToList();

            }
        }
    }
}
