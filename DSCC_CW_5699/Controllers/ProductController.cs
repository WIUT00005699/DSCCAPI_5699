using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using DSCC_CW_5699.Model;
using DSCC_CW_5699.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSCC_CW_5699.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult Get(Product product)
        {
            var products = _productRepository.GetAll();
            return new OkObjectResult(products);
            //return new string[] { "value1", "value2" };
        }
        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _productRepository.GetById(id);
            return new OkObjectResult(product);
            //return "value";
        }
        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            using (var scope = new TransactionScope())
            {
                _productRepository.Create(product);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
        }
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (product != null)
            {
                using (var scope = new TransactionScope())
                {
                    _productRepository.Update(product);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            return new OkResult();
        }
    }
}
