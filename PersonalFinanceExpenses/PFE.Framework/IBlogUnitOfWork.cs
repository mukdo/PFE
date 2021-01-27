using PFE.Data;
using PFE.Framework.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework
{
    public interface IBlogUnitOfWork:IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; set; }
    }
}
