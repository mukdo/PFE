using PFE.Data;
using PFE.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework.Repository
{
    public class ItemCategoryRepository : Repository<ItemCategory, int, FrameworkContext>, IItemCategoryRepository
    {
        public ItemCategoryRepository(FrameworkContext dbContext)
            : base(dbContext)
        {

        }
    }
}
