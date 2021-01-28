using PFE.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework.Service
{
    public interface IItemCategoryService:IDisposable
    {
        (IList<ItemCategory> categories, int total, int totalDisplay) GetItemCategories(int pageindex,
                                                                              int Pagesize,
                                                                              string searchText,
                                                                              string sortText);
        void CreateItemCategory(ItemCategory category);
        void EditItemCategory(ItemCategory category);
        ItemCategory GetItemCategory(int Id);
        ItemCategory DeleteItemCategory(int Id);
        IList<Category> GetCategory();
    }
}
