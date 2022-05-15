using Autofac;
using PFE.Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Areas.Admin.Models.Categories
{
    public class ItemCategoryBaseModel : AdminBaseModel, IDisposable
    {
        protected IItemCategoryService _categoryService;

        public ItemCategoryBaseModel(IItemCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ItemCategoryBaseModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<IItemCategoryService>();
        }
        public void Dispose()
        {
            _categoryService?.Dispose();
        }
    }
}
