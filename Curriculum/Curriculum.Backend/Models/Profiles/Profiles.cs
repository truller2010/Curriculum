#region KotikoBlog Header License

// // Solution: Curriculum
// // Project: Curriculum.Backend
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 18/01/2016   20:08
// //
// // File Modified on 18/01/2016/   20:08
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
using Curriculum.Backend.Models.Courses;
using Curriculum.Backend.Models.Education;
using Curriculum.Backend.Models.ProfilesSkillsCode;
using Curriculum.Backend.Models.ProfilesSkillsProfessionals;
using Curriculum.Backend.Models.ProfilesSkillsSoftware;
using Curriculum.Backend.Models.WorkExperiences;

#endregion

namespace Curriculum.Backend.Models.Profiles
{
    public class ProfilesResponse
    {
        public ProfilesResponse()
        {
            Courses = new List<CoursesResponse>();
            Educations = new List<EducationsResponse>();
            ProfilesSkillsCode = new List<ProfilesSkillsCodeResponse>();
            ProfilesSkillsProfessionals = new List<ProfilesSkillsProfessionalsResponse>();
            ProfilesSkillsSoftware = new List<ProfilesSkillsSoftwareResponse>();
            WorkExperiences = new List<WorkExperiencesResponse>();
        }

        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string FirstSurname { get; set; }
        public virtual string SecondSurname { get; set; }
        public virtual string Street { get; set; }
        public virtual int StreetNumber { get; set; }
        public virtual int Floor { get; set; }
        public virtual string Letter { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
        public virtual DateTime Born { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? Deleted { get; set; }
        public virtual string DeletedBy { get; set; }
        public virtual IList<CoursesResponse> Courses { get; set; }
        public virtual IList<EducationsResponse> Educations { get; set; }
        public virtual IList<ProfilesSkillsCodeResponse> ProfilesSkillsCode { get; set; }
        public virtual IList<ProfilesSkillsProfessionalsResponse> ProfilesSkillsProfessionals { get; set; }
        public virtual IList<ProfilesSkillsSoftwareResponse> ProfilesSkillsSoftware { get; set; }
        public virtual IList<WorkExperiencesResponse> WorkExperiences { get; set; }
    }
}