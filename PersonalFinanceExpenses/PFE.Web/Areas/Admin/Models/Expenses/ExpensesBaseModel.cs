using Autofac;
using PFE.Framework;
using PFE.Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Areas.Admin.Models.Expenses
{
    public class ExpensesBaseModel : AdminBaseModel, IDisposable
    {
        protected IExpensesService _expensesService;
        public ExpensesBaseModel(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        public ExpensesBaseModel()
        {
            _expensesService = Startup.AutofacContainer.Resolve<IExpensesService>();
        }

        public void Dispose()
        {
            _expensesService?.Dispose();
        }
    }
}
