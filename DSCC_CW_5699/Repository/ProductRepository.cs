using DSCC_CW_5699.DbContexts;
using DSCC_CW_5699.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW_5699.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ProductContext _dbContext;
        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Product> GetAll()
        {
            return _dbContext.Products;
        }
        public void Delete(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(product);
            Save();
        }
        public Product GetById(int productId)
        {
            var prod = _dbContext.Products.Find(productId);
            return prod;
        }
        public void Create(Product entity)
        {
            _dbContext.Add(entity);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void Update(Product entity)
        {
            _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
