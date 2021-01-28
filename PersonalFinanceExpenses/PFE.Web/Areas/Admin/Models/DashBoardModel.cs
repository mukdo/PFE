using PFE.membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Web.Areas.Admin.Models
{
    public class DashBoardModel : AdminBaseModel  
    {
        
        public ApplicationUser User { get; set; }

    }
}
