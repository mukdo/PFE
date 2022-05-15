using Autofac;
using Microsoft.AspNetCore.Mvc.Rendering;
using PFE.Framework;
using PFE.Framework.Entity;
using PFE.Framework.Service;
using PFE.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Models
{
    public class Expenses
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
        public IList<Budget> Budgets { get; set; }

        public Expenses()
        {
            _budgetService = Startup.AutofacContainer.Resolve<IBudgetService>();
        }
        public FrameworkContext  _conText { get; set; }
        protected IBudgetService _budgetService;
        public Expenses(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        //public IList<Budget > GetCategory()
        //{
        //    return _conText.Budgets.ToList(); ;
        //}
        public IList<SelectListItem> GetBudgetList()
        {
            IList<SelectListItem> listItems = new List<SelectListItem>();
            
            foreach (var item in _budgetService.GetBudgetForExpenses())
            {
                var ctg = new SelectListItem
                {
                    Text = item.Title,
                    Value = item.Id.ToString()
                };
                listItems.Add(ctg);
            }
            return listItems;
        }
    }
}
