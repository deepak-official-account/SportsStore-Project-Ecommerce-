using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
namespace SportsStore.Domain.Abstract
    {
    public interface IProductRepository
        {
        IEnumerable<Product> Products(int pageNo, int limit,string Category);
        IEnumerable<string> GetAllCategories();

        Product FindByProductId(int productId);

        void CreateProduct(Product product, Stream fileStream, string fileName);

        bool DeleteProductById(int ProductId);
        }
    }
