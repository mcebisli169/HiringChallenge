using HiringChallenge.Core.Dto;
using HiringChallenge.Core.Entity;
using HiringChallenge.Core.UnitOfWork;
using HiringChallenge.Services.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HiringChallenge.Services.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(ProductModel product)
        {
            // dispose transaction
            try
            {
                using (var transaction = _unitOfWork.BeginTransaction())
                {
                    Product newProduct = new Product();
                    newProduct.Name= product.Name;
                    newProduct.Description = product.Description;
                    newProduct.CreatedUser = Guid.NewGuid().ToString();
                    newProduct.CreatedDate = DateTime.Now;
                    newProduct.ModifiedDate = DateTime.Now;
                    newProduct.ModifiedUser = Guid.NewGuid().ToString();
                    newProduct.RowStatus = RowStatus.Active;
                     _unitOfWork.GetRepository<Product>().Add(newProduct);
                    _unitOfWork.SaveChanges();

                    foreach (int item in product.CategoryIds)
                    {
                        ProductCategory pc = new ProductCategory();
                        pc.ProductId = newProduct.Id;
                        pc.CategoryId = item;
                        pc.CreatedUser = Guid.NewGuid().ToString();
                        pc.CreatedDate = DateTime.Now;
                        pc.ModifiedDate = DateTime.Now;
                        pc.ModifiedUser = Guid.NewGuid().ToString();
                        pc.RowStatus = RowStatus.Active;

                        _unitOfWork.GetRepository<ProductCategory>().Add(pc);
                    }
                    _unitOfWork.SaveChanges();
                    _unitOfWork.CommitTransaction();
                    return newProduct.Id;
                };
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                using (var transaction = _unitOfWork.BeginTransaction())
                {
                    _unitOfWork.GetRepository<Product>().Delete(id);
                    _unitOfWork.SaveChanges();
                    _unitOfWork.CommitTransaction();
                };
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public List<Product> GetAllProducts()
        {
            var products = _unitOfWork.GetRepository<Product>().GetAll().Include(s=>s.ProductCategories);
            
            return products.ToList();
        }

        public Product GetProduct(int id)
        {
            return _unitOfWork.GetRepository<Product>().GetById(id);                        
        }

        public List<ProductListModel> GetProductListModels()
        {
            var products = _unitOfWork.GetRepository<Product>().GetAll()
                .Include(s => s.ProductCategories)
                .ThenInclude(s=>s.Category);
            
            List<ProductListModel> productsList = new List<ProductListModel>();

            foreach (var item in products)
            {
                ProductListModel prm=new ProductListModel();
                prm.Id = item.Id;
                prm.Name = item.Name;
                prm.Description = item.Description;
                prm.Categories = String.Join(",", item.ProductCategories.Select(s => s.Category.Name));
                productsList.Add(prm);
            }
            return productsList;
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                using (var transaction = _unitOfWork.BeginTransaction())
                {
                    _unitOfWork.GetRepository<Product>().Update(product);
                    _unitOfWork.SaveChanges();
                    _unitOfWork.CommitTransaction();
                };
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }
    }
}
