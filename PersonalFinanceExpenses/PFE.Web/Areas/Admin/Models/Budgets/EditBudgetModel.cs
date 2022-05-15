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
    public class EditBudgetModel : BudgetBaseModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public int Amount { get; set; }

        public int CategoryId { get; set; }
        public int ItemCategoryId { get; set; }
        public string UserId { get; set; }


        public EditBudgetModel(IBudgetService  blogComposeService) : base(blogComposeService)
        {

        }
        public EditBudgetModel() : base()
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
        public void Edit()
        {
            var blogCompose = new Budget()
            {
                Id =this.Id,
                Title = this.Title,
                Amount = this.Amount,
                ItemCategoryId = ItemCategoryId,
                UserId = this.UserId,
                CategoryId = this.CategoryId
            };

            _budgetService.EditBudget(blogCompose);
        }

        internal void Load(int id)
        {
            var blogCompose = _budgetService.GetBudget(id);

            if(blogCompose != null)
            {
                Id = blogCompose.Id;
                Title = blogCompose.Title;
                Amount = blogCompose.Amount;
                ItemCategoryId = blogCompose.ItemCategoryId;
                UserId = blogCompose.UserId;
                CategoryId = blogCompose.CategoryId;
            }
        }
    }
}