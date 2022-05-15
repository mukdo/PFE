using PFE.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework.Service
{
    public interface IExpensesService : IDisposable
    {
        (IList<Expenses> expenses, int total, int totalDisplay) GetExpenses(int pageindex,
                                                                              int Pagesize,
                                                                              string searchText,
                                                                              string sortText);
        void CreateExpenses(Expenses budget);
        void EditExpenses(Expenses budget);
        Expenses GetExpenses(int Id);
        Expenses DeleteExpenses(int Id);
        IList<Budget> GetBudget();

    }
}
