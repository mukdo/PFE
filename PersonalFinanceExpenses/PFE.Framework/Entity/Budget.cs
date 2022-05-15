using PFE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework.Entity
{
    public class Budget : IEntity<int>
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int ItemCategoryId { get; set; }
        public string UserId { get; set; }
        //public IList<Category> Categories { get; set; }
        //public IList<ItemCategory> ItemCategories { get; set; }
        //public IList<Expenses> Expenses { get; set; }

    }
}
