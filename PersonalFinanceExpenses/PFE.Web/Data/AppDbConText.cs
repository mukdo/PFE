using Microsoft.EntityFrameworkCore;
using PFE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Data
{
    public class AppDbConText : DbContext
    {
        public AppDbConText(): base()
        {

        }
        public AppDbConText(DbContextOptions<AppDbConText> options) : base(options)
        {

        }
        // public DbSet<Expenses> Expenses { get; set; }
        public DbSet<PFE.Web.Models.Task> Tasks { get; set; }
    }
}
