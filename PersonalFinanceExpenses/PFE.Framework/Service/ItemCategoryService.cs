using PFE.Framework.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PFE.Framework.Service
{
    public class ItemCategoryService : IItemCategoryService
    {
        private IBlogUnitOfWork _blogUnitOfWork;

        public ItemCategoryService(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }


    public void CreateItemCategory(ItemCategory category)
        {

            _blogUnitOfWork.ItemCategoryRepository.Add(category);
            _blogUnitOfWork.Save();
        }

        public ItemCategory DeleteItemCategory(int Id)
        {
            var category = _blogUnitOfWork.ItemCategoryRepository.GetById(Id);
            _blogUnitOfWork.ItemCategoryRepository.Remove(Id);
            _blogUnitOfWork.Save();
            return category;
        }

        public void Dispose()
        {
            _blogUnitOfWork.Dispose();
        }

        public void EditItemCategory(ItemCategory category)
        {
            var count = _blogUnitOfWork.ItemCategoryRepository.GetCount(x => x.Name == category.Name
                   && x.Id != category.Id);

            if (count > 0)
                throw new DuplicationException("Category already exists", nameof(category.Name));

            var exitingCategory = _blogUnitOfWork.ItemCategoryRepository.GetById(category.Id);
            exitingCategory.Name = category.Name;

            _blogUnitOfWork.Save();
        }

        public IList<Category> GetCategory()
        {
            return _blogUnitOfWork.CategoryRepository.GetAll();
        }

        public (IList<ItemCategory> categories, int total, int totalDisplay) GetItemCategories(int pageindex, int Pagesize, string searchText, string sortText)
        {
            var result = _blogUnitOfWork.ItemCategoryRepository.GetAll().ToList();
            return (result, 0, 0);
        }

        public ItemCategory GetItemCategory(int Id)
        {
            return _blogUnitOfWork.ItemCategoryRepository.GetById(Id);
        }
    }
}
