using Autofac;
using PFE.Data;
using PFE.membership.Contexts;
using PFE.membership.Data;
using PFE.membership.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using PFE.Framework.Repository;
using PFE.Framework.Service;

namespace PFE.Framework
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FrameworkContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            //builder.RegisterType<NewDbContext>()
            //    .WithParameter("connectionString", _connectionString)
            //    .InstancePerLifetimeScope();

            builder.RegisterType<BlogUnitOfWork>().As<IBlogUnitOfWork>()
                .InstancePerLifetimeScope();

            #region Repository
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ItemCategoryRepository>().As<IItemCategoryRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<BudgetRepository>().As<IBudgetRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ExpensesRepository>().As<IExpensesRepository>()
                .InstancePerLifetimeScope();

            #endregion

            #region Service
            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ItemCategoryService>().As<IItemCategoryService>()
               .InstancePerLifetimeScope();
            builder.RegisterType<BudgetService>().As<IBudgetService>()
               .InstancePerLifetimeScope();
            builder.RegisterType<ExpensesService>().As<IExpensesService>()
               .InstancePerLifetimeScope();
            #endregion

            builder.RegisterType<AccountSeed>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserService>().As<IUserService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<CurrentUserService>().As<ICurrentUserService>()
           .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
