using Microsoft.AspNetCore.Mvc.Rendering;
using PFE.Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Areas.Admin.Models.Expenses
{
    public class ExpensesModel : ExpensesBaseModel
    {
        public ExpensesModel(IExpensesService budgetService): base(budgetService)
        {

        }

        public ExpensesModel() : base()
        {

        }

        internal object GetBlogCompose(DataTablesAjaxRequestModel dataTables)
        {
            var data = _expensesService.GetExpenses(
                                   dataTables.PageIndex,
                                   dataTables.PageSize,
                                   dataTables.SearchText,
                                   dataTables.GetSortText(new string[] {"BudgetId", "Amount", "Date"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.expenses
                        select new string[]
                        {
                            record.BudgetId.ToString(),
                            record.Amount.ToString(),
                            record.Date.ToString(),
                            record.Id.ToString(),
                            record.UserId
                                
                        }
                   ).ToArray()

            };
        }

        public IList<SelectListItem> GetItemCategoryList()
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

        internal string Delete(int Id)
        {
            var deleteBlogCompose = _expensesService.DeleteExpenses(Id);
            return deleteBlogCompose.Amount.ToString();

        }
    }
}
