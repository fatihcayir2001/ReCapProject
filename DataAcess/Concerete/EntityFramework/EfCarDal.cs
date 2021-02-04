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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarProjectContex contex = new CarProjectContex())
            {
                if (entity.Description.Length >=2 && entity.DailyPrice>0 )
                {
                    var addedEntity = contex.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    contex.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Araba açıklaması 2 karakterden uzun ve günlük ücreti 0 dan büyük olmalıdır");
                }
            }

        }

        public void Delete(Car entity)
        {
            using (CarProjectContex contex = new CarProjectContex())
            {
                var deletedEntity = contex.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                contex.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarProjectContex contex = new CarProjectContex())
            {
                return contex.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarProjectContex contex = new CarProjectContex())
            {
                return filter == null ? contex.Set<Car>().ToList() :
                    contex.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
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
