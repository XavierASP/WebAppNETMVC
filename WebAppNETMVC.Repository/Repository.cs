using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            _bikeStoresContext.SaveChanges();
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
