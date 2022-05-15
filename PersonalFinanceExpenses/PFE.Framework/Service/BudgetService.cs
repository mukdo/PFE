using PFE.Framework.Entity;
using PFE.membership.Services;
using System.Collections.Generic;
using System.Linq;

namespace PFE.Framework.Service
{
    public class BudgetService : IBudgetService
    {
        private IBlogUnitOfWork _blogUnitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public BudgetService(IBlogUnitOfWork blogUnitOfWork , ICurrentUserService currentUserService)
        {
            _blogUnitOfWork = blogUnitOfWork;
            _currentUserService = currentUserService;
        }
        public void CreateBudget(Budget budget)
        {

            _blogUnitOfWork.BudgetRepository.Add(budget);
            _blogUnitOfWork.Save();
        }

        public Budget DeleteBudget(int Id)
        {
            var category = _blogUnitOfWork.BudgetRepository.GetById(Id);
            _blogUnitOfWork.BudgetRepository.Remove(Id);
            _blogUnitOfWork.Save();
            return category;
        }

        public void Dispose()
        {
            _blogUnitOfWork.Dispose();
        }

        public void EditBudget(Budget category)
        {
           
            var exitingCategory = _blogUnitOfWork.BudgetRepository.GetById(category.Id);
                exitingCategory.Amount = category.Amount;
                exitingCategory.Title = category.Title;
                exitingCategory.ItemCategoryId = category.ItemCategoryId;
                exitingCategory.CategoryId = category.CategoryId;

            _blogUnitOfWork.Save();

        }

        public (IList<Budget> categories, int total, int totalDisplay) GetBudgets(int pageindex, int Pagesize, string searchText, string sortText)
        {
            var user =_currentUserService.UserId.ToString();
            var result = _blogUnitOfWork.BudgetRepository.Get(u => u.UserId ==user).ToList();
            return (result,0, 0);
        }

        public Budget GetBudget(int Id)
        {
            return _blogUnitOfWork.BudgetRepository.GetById(Id);
        }

        public IList<Category> GetCategory()
        {
            return _blogUnitOfWork.CategoryRepository.GetAll();
        }

        public IList<Budget> GetBudgetForExpenses()
        {
            return _blogUnitOfWork.BudgetRepository.GetAll();
        }
        public IList<ItemCategory> GetItemCategory()
        {
            return _blogUnitOfWork.ItemCategoryRepository.GetAll();
        }
    }
}
