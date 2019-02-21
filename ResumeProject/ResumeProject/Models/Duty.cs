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
//TBD if you add the jobid here as a field it will make your views easier to manage
        public Job Job { get; set; }
    }
}
