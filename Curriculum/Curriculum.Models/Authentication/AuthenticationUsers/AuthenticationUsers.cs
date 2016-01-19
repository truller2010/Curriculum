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
using System.Collections.Generic;
using Curriculum.Models.Authentication.AuthenticationRoles;
using FluentNHibernate.Mapping;

#endregion

namespace Curriculum.Models.Authentication.AuthenticationUsers
{
    /// <summary>
    /// </summary>
    public class AuthenticationUsers
    {
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual string LockedCode { get; set; }
        public virtual byte[] Photo { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual DateTime? Deleted { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual IList<Rol> Roles { get; set; }
    }

    /// <summary>
    /// </summary>
    public class AuthenticationUsersMap : ClassMap<AuthenticationUsers>
    {
        public AuthenticationUsersMap()
        {
            Table("Authentication_Users");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Map(x => x.Nombre).Column("Nombre").Not.Nullable();
            Map(x => x.Password).Column("Password").Not.Nullable();
            Map(x => x.Email).Column("Email").Not.Nullable();
            Map(x => x.LockedCode).Column("LockedCode").Not.Nullable();
            Map(x => x.Created).Column("Created");
            Map(x => x.Deleted).Column("Deleted");
            Map(x => x.Modified).Column("Modified");
            HasMany(x => x.Roles)
                .Cascade.All()
                .Table("Authentication_UsersRoles")
                .KeyColumn("IdUser")
                .Element("IdRole");
        }
    }
}