using PFE.Framework.Entity;
using PFE.Framework.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Areas.Admin.Models.Categories
{
    public class CreateCategoryModel : CategoryBaseModel
    {
        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        public CreateCategoryModel( ICategoryService categoryService) : base(categoryService)
        {

        }

        public CreateCategoryModel() : base()
        {

        }

        public void Create()
        {
            var category = new Category
            {
                Name = this.Name
            };

            _categoryService.CreateCategory(category);
        }
    }
}
