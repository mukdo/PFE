using Autofac;
using PFE.Web.Areas.Admin.Models.Budgets;
using PFE.Web.Areas.Admin.Models.Categories;
using PFE.Web.Areas.Admin.Models.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
              builder.RegisterType<CategoryModel>();
              builder.RegisterType<ItemCategoryModel>();
              builder.RegisterType<BudgetModel>();
              builder.RegisterType<ExpensesModel>();
            base.Load(builder);
        }
    }
}
