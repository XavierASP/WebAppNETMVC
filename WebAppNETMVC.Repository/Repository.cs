using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppNETMVC.Data;

namespace WebAppNETMVC.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BikeStoresContext _bikeStoresContext;
        private readonly DbSet<TEntity> _bikeStoresEntities;

        public Repository(BikeStoresContext bikeStoresContext)
        {
            _bikeStoresContext = bikeStoresContext;
            _bikeStoresEntities = bikeStoresContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            TEntity addedEntity = _bikeStoresEntities.Add(entity);
            try 
            {
                _bikeStoresContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return addedEntity;
        }

        public void Delete(int id)
        {
            TEntity entity = _bikeStoresEntities.Find(id);
            _bikeStoresEntities.Remove(entity);
            _bikeStoresContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _bikeStoresEntities.AsEnumerable();
        }

        public TEntity GetById(int id)
        {
            return _bikeStoresEntities.Find(id);
        }

        public TEntity Update(TEntity entity)
        {
            _bikeStoresContext.Entry(entity).State = EntityState.Modified;
            _bikeStoresContext.SaveChanges();
            return entity;
        }
    }
}
