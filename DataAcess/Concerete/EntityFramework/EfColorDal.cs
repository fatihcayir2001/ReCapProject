using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concerete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concerete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, CarProjectContext>,IColorDal
    {
        
    }
}
