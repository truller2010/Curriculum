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

using System;
using System.Threading.Tasks;
using Curriculum.Core.Helper;
using Curriculum.Models.Authentication.AuthenticationRefreshToken;
using Curriculum.Service.Authentication.AuthenticationRefreshTokenService;
using Microsoft.Owin.Security.Infrastructure;
using Spring.Context.Support;

#endregion

namespace Curriculum.Backend.Providers
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {
        /// <summary>
        /// 
        /// </summary>
        private IAuthenticationRefreshTokenService AuthenticationRefreshTokenService
        {
            get { return ContextRegistry.GetContext().GetObject<IAuthenticationRefreshTokenService>(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            Create(context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            Receive(context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void Create(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:client_id"];

            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }

            var refreshTokenId = Guid.NewGuid().ToString("n");

            var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

            var token = new AuthenticationRefreshToken
            {
                Id = HelperMethods.GetHash(refreshTokenId),
                Clientid = clientid,
                Subject = context.Ticket.Identity.Name,
                Issuedutc = DateTime.UtcNow,
                Expiresutc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime))
            };

            context.Ticket.Properties.IssuedUtc = token.Issuedutc;
            context.Ticket.Properties.ExpiresUtc = token.Expiresutc;

            token.Protectedticket = context.SerializeTicket();

            AuthenticationRefreshTokenService.Save(token);

            context.SetToken(refreshTokenId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void Receive(AuthenticationTokenReceiveContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            if (context.OwinContext.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
            {
                context.OwinContext.Response.Headers["Access-Control-Allow-Origin"] = allowedOrigin;
            }
            else
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {allowedOrigin});
            }

            var hashedTokenId = HelperMethods.GetHash(context.Token);

            var refreshToken = AuthenticationRefreshTokenService.Get(hashedTokenId);

            if (refreshToken != null)
            {
                //Get protectedTicket from refreshToken class
                context.DeserializeTicket(refreshToken.Protectedticket);

                // TODO: Eliminar token en tarea cron
                //RefreshTokenService.Delete(refreshToken);
            }
        }
    }
}