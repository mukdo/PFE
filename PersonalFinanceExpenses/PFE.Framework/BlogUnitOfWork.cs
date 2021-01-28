using PFE.Data;
using PFE.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework
{
    public class BlogUnitOfWork : UnitOfWork, IBlogUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public IItemCategoryRepository ItemCategoryRepository { get; set; }

        public BlogUnitOfWork( FrameworkContext frameworkContext ,ICategoryRepository categoryRepository
                                                                 ,IItemCategoryRepository itemCategoryRepository)
            :base(frameworkContext)
        {
            CategoryRepository = categoryRepository;
            ItemCategoryRepository = itemCategoryRepository;
        }
    }
}
