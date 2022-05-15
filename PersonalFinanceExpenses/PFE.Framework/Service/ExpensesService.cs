using Microsoft.AspNetCore.Http;
using PFE.Framework.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PFE.Framework.Service
{
    public class ExpensesService : IExpensesService
    {
        private IBlogUnitOfWork _blogUnitOfWork;

        public ExpensesService(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }
        public void CreateExpenses(Expenses budget)
        {

            _blogUnitOfWork.ExpensesRepository.Add(budget);
            _blogUnitOfWork.Save();
        }

        public Expenses DeleteExpenses(int Id)
        {
            var expenses = _blogUnitOfWork.ExpensesRepository.GetById(Id);
            _blogUnitOfWork.ExpensesRepository.Remove(Id);
            _blogUnitOfWork.Save();
            return expenses;
        }

        public void Dispose()
        {
            _blogUnitOfWork.Dispose();
        }

        public void EditExpenses(Expenses category)
        {
            var exitingExpenses = _blogUnitOfWork.ExpensesRepository.GetById(category.Id);
            exitingExpenses.Amount = category.Amount;
            exitingExpenses.Date = category.Date;

            _blogUnitOfWork.Save();

        }

        public (IList<Expenses> expenses, int total, int totalDisplay) GetExpenses(int pageindex, int Pagesize, string searchText, string sortText)
        {
            var result = _blogUnitOfWork.ExpensesRepository.GetAll().ToList();
            return (result, 0, 0);
        }

        public Expenses GetExpenses(int Id)
        {
            return _blogUnitOfWork.ExpensesRepository.GetById(Id);
        }

        public IList<Budget> GetBudget()
        {
            return _blogUnitOfWork.BudgetRepository.GetAll();
        }
    }
}
