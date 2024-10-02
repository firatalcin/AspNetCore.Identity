﻿using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace IdentityExampleProject.UI.Features
{
    public class UserClaimProvider : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
            Claim claim = null;
            if (principal.HasClaim(x => x.Type == "username"))
            {
                claim = new Claim("username", identity.Name);
                identity.AddClaim(claim);
            }
            if (principal.HasClaim(x => x.Type == "logintime"))
            {
                claim = new Claim("logintime", DateTime.Now.ToString());
                identity.AddClaim(claim);
            }

            return principal;
        }
    }
}
