using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class Job
    {
        public int JobID { get; set; }
        public string Position  { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public DateTime WorkStartDate { get; set; }
        public DateTime WorkEndDate { get; set; }

        public Applicant Applicant { get; set; }
        public ICollection<Duty> Duties { get; set; }
        

    }
}
