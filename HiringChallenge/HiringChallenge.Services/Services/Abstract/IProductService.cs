using HiringChallenge.Core.Dto;
using HiringChallenge.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringChallenge.Services.Services.Abstract
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        List<ProductListModel> GetProductListModels();
        Product GetProduct(int id);
        int Add(ProductModel product); 
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
