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

namespace PFE.Web.Areas.Admin.Models.Budgets
{
    public class CreateBudgetModel : BudgetBaseModel
    {
        [Required]
        [StringLength (500 , MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public int Amount { get; set; }

        public int CategoryId { get; set; }
        public int ItemCategoryId { get; set; }
        public string UserId { get; set; }

        public CreateBudgetModel(IBudgetService  blogComposeService) : base(blogComposeService)
        {

        }

        public CreateBudgetModel() : base()
        {

        }

        public IList<SelectListItem> GetCategoryList()
        {
            IList<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in _budgetService.GetCategory())
            {
                var ctg = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listItems.Add(ctg);
            }
            return listItems;
        }

        public IList<SelectListItem> GetItemCategoryList()
        {
            IList<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in _budgetService.GetItemCategory())
            {
                var ctg = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listItems.Add(ctg);
            }
            return listItems;
        }
        public void Create()
        {
            var blogCompose = new Budget()
            {
                Title = this.Title,
                Amount = this.Amount,
                ItemCategoryId = ItemCategoryId,
                UserId =this.UserId,
                CategoryId = this.CategoryId
            };

            _budgetService.CreateBudget(blogCompose);
        }
    }
}
