using System;

using Microsoft.AspNetCore.Identity;

namespace PFE.membership.Entities
{
    public class UserClaim
        : IdentityUserClaim<Guid>
    {
        public UserClaim()
            : base()
        {

        }
    }
}
