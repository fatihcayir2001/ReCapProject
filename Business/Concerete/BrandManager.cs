using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concerete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public Brand GetBrandNameById(int brandId)
        {
            return _brandDal.Get(x => x.BrandId == brandId);
        }

        public List<Brand> GetBrands()
        {
            return _brandDal.GetAll();
        }
    }
}
