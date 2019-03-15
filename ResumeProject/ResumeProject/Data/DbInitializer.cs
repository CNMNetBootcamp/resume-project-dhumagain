using ResumeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ResumeContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            //if (context.Applicants.Any())
            //{
            //    return;   // DB has been seeded
            //}

            //var applicants = new Applicant[]
            //{
            //new Applicant{ApplicantID=1, FirstName="Dipendra",LastName="Humagain", Address="3600 Wellesley dr NE D136, ABQ NM", PhoneNumber=
            //"505-610-2941"}
            //};
            //foreach (Applicant a in applicants)
            //{
            //    context.Applicants.Add(a);
            //}
            //context.SaveChanges();




            //var educations = new Education[]
            //{
            //new Education{ApplicantID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, GPA=3.5, GraduationDate = DateTime.Parse("12-13-2020 00:00:00"), Major ="Computer Science", Minor ="N/A",
            //    SchoolAddress ="Albuquerque, NM", SchoolName="University of New Mexico" },
            //new Education{ApplicantID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, GPA=3.69, GraduationDate = DateTime.Parse("12-13-2013 00:00:00"), Major ="Chemistry", Minor ="Biology," +
            //" Psychology", SchoolAddress="Albuquerque, NM", SchoolName="University of New Mexico" },
            //new Education{ApplicantID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, GPA=3.93, GraduationDate = DateTime.Parse("12-13-2013 00:00:00"), Major ="Associate of Science, "
            //+ "Applied Science ", Minor ="N/A", SchoolAddress="Hobbs, NM", SchoolName="New Mexico Junior College" }

            //};
            //foreach (Education e in educations)
            //{
            //    context.Educations.Add(e);
            //}
            //context.SaveChanges();

            //var jobs = new Job[]
            //{
            //new Job{ApplicantID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, CompanyName ="Albuquerque Water Authority", CompanyLocation ="6000 Alexander Blvd, ABQ NM",
            //    Position ="Compliance Division Intern", WorkStartDate =DateTime.Parse("09-17-2018"), WorkEndDate = DateTime.Parse("12-30-2020")},
            //new Job{ApplicantID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, CompanyName ="Econo Lodge East", CompanyLocation ="13211 Central Ave, ABQ NM",
            //    Position ="Assistant General Manager", WorkStartDate =DateTime.Parse("05-01-2013"), WorkEndDate = DateTime.Parse("09-16-2018")}

            //};

            //foreach (Job j in jobs)
            //{
            //    context.Jobs.Add(j);
            //}
            //context.SaveChanges();

            //// 
            //var duties = new Duty[]
            //{
            //new Duty{ JobID = context.Jobs.FirstOrDefault(y => y.CompanyName =="Econo Lodge East").JobID,
            //    DutiesPerformed ="  Coordinated lodging for clients, assisted clients with transportation and provided other pertinent information. " },
            //new Duty{ JobID = context.Jobs.FirstOrDefault(y => y.CompanyName =="Econo Lodge East").JobID,
            //    DutiesPerformed ="  Trained and supervised employees; taught procedures and provided performance reviews. " },
            //new Duty{ JobID = context.Jobs.FirstOrDefault(y => y.CompanyName =="Econo Lodge East").JobID,
            //    DutiesPerformed ="  Created official correspondence to clients, as well as all hotel departments. " },
            //new Duty{ JobID = context.Jobs.FirstOrDefault(y => y.CompanyName =="Econo Lodge East").JobID,
            //    DutiesPerformed ="  Communicated extensively with clients and vendors. " },
            //new Duty{ JobID = context.Jobs.FirstOrDefault(y => y.CompanyName =="Econo Lodge East").JobID,
            //    DutiesPerformed ="  Set-up and managed direct billing with vendor companies. " },                       

            //new Duty{ JobID = context.Jobs.FirstOrDefault(y => y.CompanyName =="Albuquerque Water Authority").JobID,
            //    DutiesPerformed ="  Sort, categorize, and analyze Water Authority lab samples data. " },
            //new Duty{ JobID = context.Jobs.FirstOrDefault(y => y.CompanyName =="Albuquerque Water Authority").JobID,
            //    DutiesPerformed ="  Currently creating a database for past and current samples data. " },
            //new Duty{ JobID = context.Jobs.FirstOrDefault(y => y.CompanyName =="Albuquerque Water Authority").JobID,
            //    DutiesPerformed ="  Monitor well water sites.  " },
            //new Duty{ JobID = context.Jobs.FirstOrDefault(y => y.CompanyName =="Albuquerque Water Authority").JobID,
            //    DutiesPerformed ="  Transcribed customer needs and assisted with customer solutions." }
            //};

            //foreach (Duty d in duties)
            //{
            //    context.Duties.Add(d);
            //}
            //context.SaveChanges();

            //var references = new Reference[]
            //{
            //new Reference{ ApplicantID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, FirstName ="Elizabeth ", LastName = "Anderson", PhoneNumber = "505-289-3382"},
            //new Reference{ ApplicantID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, FirstName ="Michael ", LastName = "Richardson", PhoneNumber = "505-289-3383"},
            //new Reference{ ApplicantID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, FirstName ="Jay", LastName = "Shah", PhoneNumber = "505-292-7600"}
            //};

            //foreach (Reference r in references)
            //{
            //    context.References.Add(r);
            //}
            //context.SaveChanges();


        }
    }
}
