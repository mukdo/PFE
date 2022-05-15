using PFE.Framework.Entity;
using PFE.Framework.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Areas.Admin.Models.Categories
{
    public class ItemCreateCategoryModel : ItemCategoryBaseModel
    {
        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        public ItemCreateCategoryModel( IItemCategoryService categoryService) : base(categoryService)
        {

        }

        public ItemCreateCategoryModel() : base()
        {

        }

        public void Create()
        {
            var category = new ItemCategory
            {
                Name = this.Name
            };

            _categoryService.CreateItemCategory(category);
        }
    }
}
