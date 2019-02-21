using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class Applicant
    {
        public int ApplicantID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        public ICollection<Education> Educations { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public ICollection<Reference> References { get; set; }
        
    }
}
