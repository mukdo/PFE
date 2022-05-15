using PFE.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework.Service
{
    public interface IBudgetService : IDisposable
    {
        (IList<Budget> categories, int total, int totalDisplay) GetBudgets(int pageindex,
                                                                              int Pagesize,
                                                                              string searchText,
                                                                              string sortText);
        void CreateBudget(Budget budget);
        void EditBudget(Budget budget);
        Budget GetBudget(int Id);
        Budget DeleteBudget(int Id);
        IList<Category> GetCategory();
        IList<Budget> GetBudgetForExpenses();
        IList<ItemCategory> GetItemCategory();

    }
}
