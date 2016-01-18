#region Curriculum Header License

// // Solution: Curriculum
// // Project: Curriculum.Backend
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 14/01/2016   14:29
// //
// // File Modified on 14/01/2016/   14:29
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
using Curriculum.Backend.Providers;
using Curriculum.Service.Authentication.AuthenticationRefreshTokenService;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Spring.Context.Support;

#endregion

namespace Curriculum.Backend
{
    public partial class Startup
    {
        public const string TokenEndpointPath = "/api/token";
        public const string PublicClientId = "self";

        static Startup()
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString(TokenEndpointPath),
                Provider = new SimpleAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                AllowInsecureHttp = true,
                RefreshTokenProvider = new SimpleRefreshTokenProvider()
            };
        }

        private IAuthenticationRefreshTokenService AuthenticationRefreshTokenService
        {
            get { return ContextRegistry.GetContext().GetObject<IAuthenticationRefreshTokenService>(); }
        }

        public static OAuthAuthorizationServerOptions OAuthOptions { get; }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthAuthorizationServer(OAuthOptions);

            var OAuthBearerOptions = new OAuthBearerAuthenticationOptions
            {
                Provider = new OAuthBearerAuthenticationProvider
                {
                    OnRequestToken = context => { return Task.FromResult<object>(null); }
                }
            };
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }
    }
}