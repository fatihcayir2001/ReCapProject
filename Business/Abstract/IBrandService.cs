using Entites.Concerete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        public List<Brand> GetBrands();
        public Brand GetBrandNameById(int brandId);
    }
}
