using PFE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Framework.Categories
{
    public class Category:IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
