using PFE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework.Categories
{
    public interface ICategoryRepository : IRepository<Category, int, FrameworkContext>
    {
    }
}
