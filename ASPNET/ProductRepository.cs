﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using ASPNET.Models;

namespace ASPNET
{
    public class ProductRepository : IProductRepository
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

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id",
               new { id = id });
        }

        public void UpdateProduct(Product product)
        {
             _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
                new { name = product.Name, price = product.Price, id = product.ProductID });
        }

       
            
    }
}
