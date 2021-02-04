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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (CarProjectContex contex = new CarProjectContex())
            {
                var addedEntity = contex.Entry(entity);
                addedEntity.State = EntityState.Added;
                contex.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (CarProjectContex contex = new CarProjectContex())
            {
                var deletedEntity = contex.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                contex.SaveChanges();
             }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (CarProjectContex contex = new CarProjectContex())
            {
                return contex.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarProjectContex contex = new CarProjectContex())
            {
                return filter == null ? contex.Set<Brand>().ToList() :
                    contex.Set<Brand>().Where(filter).ToList();
            } 
        }

        public void Update(Brand entity)
        {
            using (CarProjectContex contex = new CarProjectContex())
            {
                var updatedEntity = contex.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                contex.SaveChanges();
            }
        }
    }
}
