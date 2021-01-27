using System;

using Microsoft.AspNetCore.Identity;

namespace PFE.membership.Entities
{
    public class UserToken
        : IdentityUserToken<Guid>
    {
        public UserToken()
            : base()
        {

        }
    }
}
