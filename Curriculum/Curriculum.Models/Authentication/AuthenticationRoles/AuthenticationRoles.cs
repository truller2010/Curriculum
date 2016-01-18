#region Curriculum Header License

// // Solution: Curriculum
// // Project: Curriculum.Models
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 14/01/2016   14:52
// //
// // File Modified on 14/01/2016/   14:52
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

using Curriculum.Core.Helper;

#endregion

namespace Curriculum.Models.Authentication.AuthenticationRoles
{
    /// <summary>
    /// 
    /// </summary>
    public enum Rol
    {
        [StringValue("SUPERADMIN")] Superadministrador = 0,

        [StringValue("ADMIN")] Administrador = 1,

        [StringValue("AAA")] AAA = 2,

        [StringValue("ALA")] ALA = 3,

        [StringValue("PTECNICO")] PTECNICO = 4,

        [StringValue("DCPRH")] DCPRH = 5,

        [StringValue("DGCRH")] DGCRH = 6,

        [StringValue("ANA")] ANA = 7,

        [StringValue("DARH")] DARH = 8,

        [StringValue("UCRE")] UCRE = 9,

        [StringValue("BU")] BU = 10,

        [StringValue("JU")] JU = 11,

        [StringValue("USUARIO")] USUARIO = 12,

        [StringValue("EMPRESA")] EMPRESA = 13
    }
}