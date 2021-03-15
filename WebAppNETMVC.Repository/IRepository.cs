using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppNETMVC.Repository
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);

        TEntity Update(TEntity entity);

        TEntity Add(TEntity entity);

        void Delete(int id);
    }
}
