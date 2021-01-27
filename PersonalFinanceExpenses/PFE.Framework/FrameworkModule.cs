using Autofac;
using PFE.Data;
using PFE.Framework.Categories;
using PFE.membership.Contexts;
using PFE.membership.Data;
using PFE.membership.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

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

            builder.RegisterType<BlogUnitOfWork>().As<IBlogUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerLifetimeScope();

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
