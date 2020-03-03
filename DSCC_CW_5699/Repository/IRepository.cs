using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW_5699.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int Id);
    }
}
