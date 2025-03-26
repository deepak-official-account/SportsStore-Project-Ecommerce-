
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using CloudinaryDotNet;
using SportsStore.Domain.Abstract;

using SportsStore.Domain.Entities;
using SportsStore.Domain.Services;
namespace SportsStore.Domain.Concrete
    {
    public class ProductRepository : IProductRepository
        {
        private readonly ProductDbContext productDbContext = new ProductDbContext();
        private readonly CloudinaryService _cloudinaryService=new CloudinaryService();


        public IEnumerable<Product> Products(int pageNo, int limit,string Category)
            {
            return productDbContext.Products
                   .Where(p => Category == null || p.Category == Category)
               .OrderBy(p => p.ProductId)
               .Skip((pageNo - 1) * limit)
               .Take(limit)
               .ToList();
            
            }

        public IEnumerable<string> GetAllCategories()
            {
           return   this.productDbContext.Products.Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            }

        public Product FindByProductId(int productId)
            {
            Product product = this.productDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
            return product;
            }

        public void CreateProduct(Product product, Stream fileStream, string fileName)
            {
            var responseData = _cloudinaryService.UploadImage(fileStream, fileName);
            product.ImagePublicId = responseData.PublicId.ToString();
            product.ImageUrl = responseData.Url.ToString();
            productDbContext.Products.Add(product);
            productDbContext.SaveChanges();
            }

        public bool DeleteProductById(int ProductId)
            {
            Product product = this.productDbContext.Products.FirstOrDefault(p => p.ProductId == ProductId);
            Product response=null;
            if (product != null)
                {
                response=this.productDbContext.Products.Remove(product);
                }
            return   response!=null;
            }
        }
    }

