using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concerete.EntityFramework
{
    public class EfUserDal: EfEntityRepositoryBase<User,CarProjectContex>,IUserDal
    {
    }
}
