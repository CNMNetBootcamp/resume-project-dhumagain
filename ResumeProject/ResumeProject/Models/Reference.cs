using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class Reference
    {
        public int ReferenceID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }

        public int ApplicantID { get; set; }    
        public Applicant Applicant { get; set; }
    }
}
