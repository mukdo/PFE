using Autofac;
using PFE.Framework;
using PFE.Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Areas.Admin.Models.Budgets
{
    public class BudgetBaseModel : AdminBaseModel, IDisposable
    {
        protected IBudgetService  _budgetService;
        public BudgetBaseModel(IBudgetService blogComposeService)
        {
            _budgetService = blogComposeService;
        }

        public BudgetBaseModel()
        {
            _budgetService = Startup.AutofacContainer.Resolve<IBudgetService>();
        }

        public void Dispose()
        {
            _budgetService?.Dispose();
        }
    }
}
