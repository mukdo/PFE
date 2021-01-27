﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web
{
    public class WebModule
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        //protected override void Load(ContainerBuilder builder)
        //{
        //  //  builder.RegisterType<CategoryModel>();
        //    base.Load(builder);
        //}
    }
}
