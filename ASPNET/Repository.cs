using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ASPNET
{
    public class Repository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("Select * FROM products;");
        }

        public IProductRepository GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id",
               new { id = id });
        }

        public IActionResult ViewProduct(int id)
        {
            var product = Repository.GetProduct(id);

            return View(product);
        }
            
    }
}
