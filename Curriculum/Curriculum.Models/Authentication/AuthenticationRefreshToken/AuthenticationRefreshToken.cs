#region KotikoBlog Header License

// // Solution: Curriculum
// // Project: Curriculum.Models
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 16/01/2016   23:11
// //
// // File Modified on 16/01/2016/   23:11
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
using FluentNHibernate.Mapping;

#endregion

namespace Curriculum.Models.Authentication.AuthenticationRefreshToken
{
    /// <summary>
    /// </summary>
    public class AuthenticationRefreshToken
    {
        public virtual string Id { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Clientid { get; set; }
        public virtual DateTime Issuedutc { get; set; }
        public virtual DateTime Expiresutc { get; set; }
        public virtual string Protectedticket { get; set; }
    }

    /// <summary>
    /// </summary>
    public class AuthenticationRefreshtokenMap : ClassMap<AuthenticationRefreshToken>
    {
        /// <summary>
        /// </summary>
        public AuthenticationRefreshtokenMap()
        {
            Table("Authentication_RefreshToken");
            LazyLoad();
            Id(x => x.Id).Column("Id");
            Map(x => x.Subject).Column("Subject").Not.Nullable();
            Map(x => x.Clientid).Column("ClientId").Not.Nullable();
            Map(x => x.Issuedutc).Column("IssuedUtc").Not.Nullable();
            Map(x => x.Expiresutc).Column("ExpiresUtc").Not.Nullable();
            Map(x => x.Protectedticket).Column("ProtectedTicket").Not.Nullable();
        }
    }
}