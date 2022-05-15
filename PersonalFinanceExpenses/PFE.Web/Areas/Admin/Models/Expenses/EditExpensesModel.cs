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
    public class EditExpensesModel : ExpensesBaseModel
    {
        public int Id { get; set; }
        [Required]
        public int Amount { get; set; }
        public string Title { get; set; }
        public int BudgetId { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }


        public EditExpensesModel(IExpensesService blogComposeService) : base(blogComposeService)
        {

        }
        public EditExpensesModel() : base()
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
        public void Edit()
        {
            var blogCompose = new PFE.Framework.Entity.Expenses()
            {
                Id =this.Id,
                Amount = this.Amount,
                UserId = this.UserId,
                BudgetId = this.BudgetId,
                Date = this.Date
            };

            _expensesService.EditExpenses(blogCompose);
        }

        internal void Load( int id)
        {
            var blogCompose = _expensesService.GetExpenses(id);

            if(blogCompose != null)
            {
                Id = blogCompose.Id;
                Amount = blogCompose.Amount;
                UserId = blogCompose.UserId;
                BudgetId = blogCompose.BudgetId;
                Date = blogCompose.Date;
            }
        }
    }
}