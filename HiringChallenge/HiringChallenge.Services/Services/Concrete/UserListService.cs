using HiringChallenge.Core.Dto;
using HiringChallenge.Core.Entity;
using HiringChallenge.Core.UnitOfWork;
using HiringChallenge.Services.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HiringChallenge.Services.Services.Concrete
{
    public class UserListService : IUserListService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserListService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        public void CreateList(UserListCategoryModel model)
        {
            try
            {
                using (var transaction = _unitOfWork.BeginTransaction())
                {
                    UserList userList = new UserList();
                    userList.Name = model.Name;
                    userList.CreatedDate = DateTime.Now;
                    userList.CreatedUser = Guid.NewGuid().ToString();
                    userList.ModifiedDate = DateTime.Now;
                    userList.ModifiedUser = Guid.NewGuid().ToString();
                    userList.RowStatus = RowStatus.Active;
                    userList.CompletedDate = DateTime.Now;
                    userList.ListOwner = Guid.NewGuid().ToString();
                    _unitOfWork.GetRepository<UserList>().Add(userList);
                    _unitOfWork.SaveChanges();

                    foreach (var item in model.CategoryIds)
                    {
                        UserCategoryList category = new UserCategoryList();
                        category.CategoryId = item;
                        category.UserListId=userList.Id;

                        category.CreatedDate = DateTime.Now;
                        category.CreatedUser = Guid.NewGuid().ToString();
                        category.ModifiedDate = DateTime.Now;
                        category.ModifiedUser = Guid.NewGuid().ToString();
                        category.RowStatus = RowStatus.Active;

                        _unitOfWork.GetRepository<UserCategoryList>().Add(category);
                    }
                    _unitOfWork.SaveChanges();

                    _unitOfWork.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                using(var transaction = _unitOfWork.BeginTransaction())
                {
                    _unitOfWork.GetRepository<Category>().Delete(id);
                    _unitOfWork.SaveChanges();
                    _unitOfWork.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public void DeleteList(int id)
        {
            try
            {
                using (var transaction = _unitOfWork.BeginTransaction())
                {
                    _unitOfWork.GetRepository<UserList>().Delete(id);
                    _unitOfWork.SaveChanges();
                    _unitOfWork.CommitTransaction();
                }
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
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public List<Category> GetAllCategories()
        {
            var categories = _unitOfWork.GetRepository<Category>().GetAll().Where(s => s.RowStatus == RowStatus.Active);
            var data = categories.ToList();
            return data;
        }

        public List<UserList> GetAllLists()
        {
            var userLists = _unitOfWork.GetRepository<UserList>().GetAll().Where(s => s.RowStatus == RowStatus.Active);
            return userLists.ToList();  
        }

        public List<Product> GetAllProducts()
        {
            var products = _unitOfWork.GetRepository<Product>().GetAll().Where(s => s.RowStatus == RowStatus.Active);
            var data = products.ToList();
            return data;
        }


        public Category GetCategory(int id)
        {
            return _unitOfWork.GetRepository<Category>().GetById(id);
        }

        public Product GetProduct(int id)
        {
            return _unitOfWork.GetRepository<Product>().GetById(id);
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                using (var transaction = _unitOfWork.BeginTransaction())
                {
                    _unitOfWork.GetRepository<Category>().Update(category);
                    _unitOfWork.SaveChanges();
                    _unitOfWork.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public void UpdateList(UserList UserList)
        {
            try
            {
                using (var transaction = _unitOfWork.BeginTransaction())
                {
                    _unitOfWork.GetRepository<UserList>().Update(UserList);
                    _unitOfWork.SaveChanges();
                    _unitOfWork.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public void UpdateList(int id)
        {
            throw new NotImplementedException();
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
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }
        public UserList GetByUserListId(int id)
        {
            return _unitOfWork.GetRepository<UserList>().GetById(id);
        }
    }
}
