using Book.DataAccess.Repository.IRepository;
using Book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public AppDbContext _db;

        public ProductRepository(AppDbContext db) : base(db) 
        {
            _db = db;
        }

        // EQUIVALENT TO STORED PROCEDURES AND TRIGGERS | BUSINESS LOGIC
        public void Update(Product product)
        {
            var dbObj = _db.Products.FirstOrDefault(u=>u.Id == product.Id);
            if (dbObj != null) 
            { 
                dbObj.Title = product.Title;
                dbObj.Description = product.Description;    
                dbObj.Category = product.Category;  
                dbObj.ListPrice = product.ListPrice;
                dbObj.Price = product.Price;
                dbObj.Price50 = product.Price50;
                dbObj.Price100 = product.Price100;
                dbObj.ISBN = product.ISBN;
                dbObj.Author = product.Author;

                if (dbObj.ImageUrl != null) 
                { 
                    dbObj.ImageUrl = dbObj.ImageUrl;
                }
                
            }
        }
    }
}
