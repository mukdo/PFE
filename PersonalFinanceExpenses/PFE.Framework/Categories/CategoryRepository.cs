using PFE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework.Categories
{
    public class CategoryRepository : Repository<Category, int, FrameworkContext>, ICategoryRepository
    {
        public CategoryRepository(FrameworkContext dbContext)
            : base(dbContext)
        {

        }
    }
}
