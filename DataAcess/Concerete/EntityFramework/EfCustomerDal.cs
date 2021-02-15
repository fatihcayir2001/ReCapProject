using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concerete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concerete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarProjectContex>, ICustomerDal
    {
        
    }
}
