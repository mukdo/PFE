using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PFE.Framework.Entity;
using PFE.Framework.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Areas.Admin.Models.Expenses
{
    public class CreateExpensesModel : ExpensesBaseModel
    {

        [Required]
        public int Amount { get; set; }
        public int BudgetId { get; set; }
        public string UserId { get; set; }
        public DateTime DateTime { get; set; }

        public CreateExpensesModel(IExpensesService  blogComposeService) : base(blogComposeService)
        {

        }

        public CreateExpensesModel() : base()
        {

        }

        public IList<SelectListItem> GetCategoryList()
        {
            IList<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in _expensesService.GetBudget())
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

        public void Create()
        {
            var blogCompose = new PFE.Framework.Entity.Expenses()
            {
                Amount = this.Amount,
                UserId =this.UserId,
                Date = this.DateTime,
                BudgetId = this.BudgetId
            };

            _expensesService.CreateExpenses(blogCompose);
        }
    }
}
