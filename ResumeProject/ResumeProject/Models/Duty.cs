using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Models
{
    public class Duty
    {
        public int DutyID { get; set; }
        public string DutiesPerformed { get; set; }

        public Job Job { get; set; }
    }
}
