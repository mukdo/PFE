using PFE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework.Entity
{
    public class Expenses : IEntity<int>
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int BudgetId { get; set; }
        public string UserId { get; set; }
      //  public IList<Budget> Budgets { get; set; }
    }
}
