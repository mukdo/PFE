using PFE.Framework.Entity;
using PFE.Framework.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Areas.Admin.Models.Categories
{
    public class ItemEditCategoryModel : ItemCategoryBaseModel
    {
        public int Id { get; set; }

        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        public ItemEditCategoryModel( IItemCategoryService categoryService) : base(categoryService)
        {

        }

        public ItemEditCategoryModel() : base()
        {

        }

        public void Edit()
        {
            var category = new ItemCategory
            {
                Id = this.Id,
                Name = this.Name
            };

            _categoryService.EditItemCategory(category);
        }

        internal void Load(int id)
        {
            var category = _categoryService.GetItemCategory(id);
            if (category != null)
            {
                Id = category.Id;
                Name = category.Name;
            }
        }
    }
}
