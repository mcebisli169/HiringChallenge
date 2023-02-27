using HiringChallenge.Core.Entity;
using HiringChallenge.Core.UnitOfWork;
using HiringChallenge.Services.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringChallenge.Services.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateCategory(Category category)
        {
            try
            {
                using (var transaction = _unitOfWork.BeginTransaction())
                {
                    category.CreatedDate = DateTime.Now;
                    category.CreatedUser = Guid.NewGuid().ToString();
                    category.ModifiedDate = DateTime.Now;
                    category.ModifiedUser=Guid.NewGuid().ToString();
                    category.RowStatus = RowStatus.Active;
                     _unitOfWork.GetRepository<Category>().Add(category);
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
                using (var transaction = _unitOfWork.BeginTransaction())
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

        public List<Category> GetALlCategories()
        {
            var categories = _unitOfWork.GetRepository<Category>().GetAll().Where(s=>s.RowStatus== RowStatus.Active);
            var data= categories.ToList();
            return data;
        }

        public Category GetByCategoryId(int id)
        {
           return _unitOfWork.GetRepository<Category>().GetById(id);
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
    }
}
