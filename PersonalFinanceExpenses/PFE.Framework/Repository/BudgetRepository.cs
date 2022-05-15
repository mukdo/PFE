using PFE.Data;
using PFE.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework.Repository
{
    public class BudgetRepository : Repository<Budget, int, FrameworkContext>, IBudgetRepository
    {
        public BudgetRepository(FrameworkContext dbContext)
            : base(dbContext)
        {

        }
    }
}
