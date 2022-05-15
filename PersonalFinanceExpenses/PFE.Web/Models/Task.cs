using PFE.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public string TaskName { get; set; }
        public string Discription { get; set; }
        public DateTime Time { get; set; }
        public string UserId { get; set; }

        public void DateRemaining()
        {
            
        }

    }
}
