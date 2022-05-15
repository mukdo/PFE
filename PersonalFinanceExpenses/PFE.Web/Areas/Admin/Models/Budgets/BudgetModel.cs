using Microsoft.AspNetCore.Mvc.Rendering;
using PFE.Framework;
using PFE.Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Areas.Admin.Models.Budgets
{
    public class BudgetModel : BudgetBaseModel
    {
        public string MyProperty { get; set; }
        public BudgetModel(IBudgetService budgetService): base(budgetService)
        {

        }

        public BudgetModel() : base()
        {

        }

        internal object GetBlogCompose(DataTablesAjaxRequestModel dataTables)
        {
            var data = _budgetService.GetBudgets(
                                   dataTables.PageIndex,
                                   dataTables.PageSize,
                                   dataTables.SearchText,
                                   dataTables.GetSortText(new string[] { "Title", "Amount", "CategoryId", "ItemCategoryId" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.categories
                        select new string[]
                        {
                                record.Title,
                                record.Amount.ToString(),
                                record.CategoryId.ToString(),
                                record.ItemCategoryId.ToString(),
                                record.Id.ToString(),
                          
                                
                        }
                   ).ToArray()

            };
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

        internal string Delete(int Id)
        {
            var deleteBlogCompose = _budgetService.DeleteBudget(Id);
            return deleteBlogCompose.Title;

        }
    }
}
