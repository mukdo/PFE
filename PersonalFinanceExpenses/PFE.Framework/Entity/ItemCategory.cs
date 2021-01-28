using PFE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework.Entity
{
    public class ItemCategory:IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public IList<Category> Category { get; set; }
    }
}
