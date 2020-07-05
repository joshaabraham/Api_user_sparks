using Microsoft.Owin.Security.OAuth;
using OauthApp.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OauthApp.Provider
{
    public class OauthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            using (var db = new UserLoginEntities())
            {
                if (db != null)
                {
                    var user = db.Login.Where(o => o.Email == context.UserName && o.Password == context.Password).FirstOrDefault();
                    if (user != null)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRole));
                        identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                        identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                        await Task.Run(() => context.Validated(identity));
                    }
                    else
                    {
                        context.SetError("Wrong Crendtials", "Provided username and password is incorrect");
                    }
                }
                else
                {
                    context.SetError("Wrong Crendtials", "Provided username and password is incorrect");
                }
                return;
            }
        }

    }
}