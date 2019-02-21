using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class Education
    {
        public int EducationID { get; set; }
        public string SchoolName  { get; set; }
        public string SchoolAddress { get; set; }
        public string Major { get; set; }
        public string Minor { get; set; }
        public int GPA { get; set; }
        public DateTime GraduationDate { get; set; }

        public Applicant Applicant { get; set; }
    }
}
