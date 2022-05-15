using PFE.Data;
using PFE.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework.Repository
{
    public class ExpensesRepository : Repository<Expenses, int, FrameworkContext>, IExpensesRepository
    {
        public ExpensesRepository(FrameworkContext dbContext)
            : base(dbContext)
        {

        }
    }
}
