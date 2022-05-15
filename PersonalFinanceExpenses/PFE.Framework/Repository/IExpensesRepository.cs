using PFE.Data;
using PFE.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework.Repository
{
    public interface IExpensesRepository : IRepository<Expenses, int, FrameworkContext>
    {
    }
}
