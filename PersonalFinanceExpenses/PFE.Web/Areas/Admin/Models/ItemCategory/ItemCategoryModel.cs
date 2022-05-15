using Microsoft.AspNetCore.Mvc.Rendering;
using PFE.Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Areas.Admin.Models.Categories
{
    public class ItemCategoryModel : ItemCategoryBaseModel
    {
        public ItemCategoryModel( IItemCategoryService categoryService)  : base ( categoryService) { }
        public ItemCategoryModel()  : base () { }

        internal object GetCategory(DataTablesAjaxRequestModel dataTables)
        {
            var data = _categoryService.GetItemCategories(
                                    dataTables.PageIndex,
                                    dataTables.PageSize,
                                    dataTables.SearchText,
                                    dataTables.GetSortText(new string[] { "Id", "Name" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.categories
                        select new string[]
                        {
                                record.Name,
                                record.Id.ToString()
                        }
                   ).ToArray()

            };
        }
        public IList<SelectListItem> GetCategoryList()
        {
            IList<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in _categoryService.GetCategory())
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

        internal string Delete (int Id)
        {
            var deleteCategory = _categoryService.DeleteItemCategory(Id);
            return deleteCategory.Name;

        }
        
    }
        
    
}
