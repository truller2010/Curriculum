#region Curriculum Header License

// // Solution: Curriculum
// // Project: Curriculum.Backend
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 14/01/2016   14:38
// //
// // File Modified on 14/01/2016/   14:38
// 
// // Permission is hereby granted, free of charge, to any person obtaining a copy
// // of this software and associated documentation files (the "Software"), to deal
// // in the Software without restriction, including without limitation the rights
// // to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// // copies of the Software, and to permit persons to whom the Software is
// // furnished to do so, subject to the following conditions:
// //
// // The above copyright notice and this permission notice shall be included in all
// // copies or substantial portions of the Software.
// //
// // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// // SOFTWARE.

#endregion

#region

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Curriculum.Backend.Models.Authentication.Enums;
using Curriculum.Core.Helper;
using Curriculum.Models.Authentication.AuthenticationClient;
using Curriculum.Models.Authentication.AuthenticationUsers;
using Curriculum.Service.Authentication.AuthenticationClientService;
using Curriculum.Service.Authentication.AuthenticationUsersService;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Spring.Context.Support;

#endregion

namespace Curriculum.Backend.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// 
        /// </summary>
        private IAuthenticationUsersService AuthenticationUsersService
        {
            get { return ContextRegistry.GetContext().GetObject<IAuthenticationUsersService>(); }
        }

        /// <summary>
        /// 
        /// </summary>
        private IAuthenticationClientService AuthenticationClientService
        {
            get { return ContextRegistry.GetContext().GetObject<IAuthenticationClientService>(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            var clientId = string.Empty;
            var clientSecret = string.Empty;
            AuthenticationClient client = null;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                context.SetError("invalid_clientId", "ClientId should be sent.");
                return Task.FromResult<object>(null);
            }

            client = AuthenticationClientService.Get(context.ClientId);

            if (client == null)
            {
                context.SetError("invalid_clientId",
                    string.Format("Client '{0}' is not registered in the system.", context.ClientId));
                return Task.FromResult<object>(null);
            }

            if (client.Applicationtype.Equals(ApplicationTypes.NativeConfidential))
            {
                if (string.IsNullOrWhiteSpace(clientSecret))
                {
                    context.SetError("invalid_clientId", "Client secret should be sent.");
                    return Task.FromResult<object>(null);
                }
                if (client.Secret != HelperMethods.GetHash(clientSecret))
                {
                    context.SetError("invalid_clientId", "Client secret is invalid.");
                    return Task.FromResult<object>(null);
                }
            }

            if (!client.Active)
            {
                context.SetError("invalid_clientId", "Client is inactive.");
                return Task.FromResult<object>(null);
            }

            context.OwinContext.Set("as:clientAllowedOrigin", client.Allowedorigin);
            context.OwinContext.Set("as:clientRefreshTokenLifeTime", client.Refreshtokenlifetime.ToString());

            context.Validated();
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");

            if (allowedOrigin == null) allowedOrigin = "*";

            if (context.OwinContext.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
            {
                context.OwinContext.Response.Headers["Access-Control-Allow-Origin"] = allowedOrigin;
            }
            else
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {allowedOrigin});
            }

            long userCurCurriculum = 0;
            AuthenticationUsers user = null;

            user = AuthenticationUsersService.GetByUsernameAndPassword(context.UserName,
                HelperMethods.GetHash(context.Password));

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

            var rolesString = string.Join(",", user.Roles.Select(x => StringEnum.GetStringValue(x)).ToArray());

            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                {
                    "as:client_id", context.ClientId ?? string.Empty
                },
                {
                    "username", context.UserName
                },
                {
                    "roles", rolesString
                },
                {
                    "id", user.Id.ToString()
                },
                {
                    "email", user.Email
                }
            });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            if (originalClient != currentClient)
            {
                context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                return Task.FromResult<object>(null);
            }

            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}