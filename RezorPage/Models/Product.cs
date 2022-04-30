using RezorPage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using RezorPage.Data;

namespace RezorPage.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
    }




    public class ProductService : IProductService

    {
        private readonly DataBaseContext _context;

        public ProductService(DataBaseContext contxet)
        {
            _context = contxet;
        }
        public int Add(ProductDto product)
        {
            _context.Products.Add(new Models.Product
            {
                Description = product.Description,
                Name = product.Name,
                Price = product.Price
            });

           return _context.SaveChanges();
            
        }

        public int Delete(int Id)
        {
            _context.Products.Remove(new Product
            {
                Id = Id,
            });
            return _context.SaveChanges();
        }

        public ProductDto Edit(ProductDto product)
        {
            var entity = _context.Products.Find(product.Id);
            entity.Description = entity.Description;
            entity.Name = entity.Name;
            entity.Price = entity.Price;
            _context.SaveChanges();
            return product;
        }

        public ProductDto Find(int Id)
        {
            var product = _context.Products.Find(Id);
            return new ProductDto
            {
                Description = product.Description,
                Id=product.Id,
                Name=product.Name,
                Price =product.Price
            };
        }

        public List<ProductDto> List()
        {
            var products = _context.Products
                .OrderByDescending(p => p.Id)
                .Select(p => new ProductDto
                {
                    Description = p.Description,
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToList();
            return products;
        }

        public List<ProductDto> Search(string name)
        {
            var products = _context.Products
                .Where(p=>p.Name.Contains(name))
                .OrderByDescending(p => p.Id)
                .Select(p => new ProductDto
                {
                    Description = p.Description,
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToList();
            return products;
        }
    }
}
