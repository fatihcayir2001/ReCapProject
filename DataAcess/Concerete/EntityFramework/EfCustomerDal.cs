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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from c in context.Customers
                    join u in context.Users on c.CustomerId equals u.Id
                    select new CustomerDetailDto()
                    {
                        Email = u.Email,
                        CompanyName = c.CompanyName,
                        CustomerFirstName = u.FirstName,
                        CustomerLastName = u.LastName,
                        CustomerId = c.CustomerId
                    };
                return filter == null ? result.ToList() :
                    result.Where(filter).ToList();
            }
        }
    }
}
