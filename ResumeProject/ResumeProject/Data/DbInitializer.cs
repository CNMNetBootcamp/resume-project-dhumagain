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

            var educations = new Education[]
            {
            new Education{ApplicantID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, GPA=3.5, GraduationDate = DateTime.Parse("12-13-2020 00:00:00"), Major ="Computer Science", Minor ="N/A",
                SchoolAddress ="Albuquerque, NM", SchoolName="University of New Mexico" },
            new Education{ApplicantID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, GPA=3.69, GraduationDate = DateTime.Parse("12-13-2013 00:00:00"), Major ="Chemistry", Minor ="Biology," +
            " Psychology", SchoolAddress="Albuquerque, NM", SchoolName="University of New Mexico" },
            new Education{ApplicantID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, GPA=3.93, GraduationDate = DateTime.Parse("12-13-2013 00:00:00"), Major ="Associate of Science, " 
            + "Applied Science ", Minor ="N/A", SchoolAddress="Hobbs, NM", SchoolName="New Mexico Junior College" }

            };
            foreach (Education e in educations)
            {
                context.Educations.Add(e);
            }
            context.SaveChanges();

            var jobs = new Job[]
            {
            new Job{ApplicantID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, CompanyName ="Albuquerque Water Authority", CompanyLocation ="6000 Alexander Blvd, ABQ NM",
                Position ="Compliance Division Intern", WorkStartDate =DateTime.Parse("09-17-2018"), WorkEndDate = DateTime.Parse("12-30-2020")},
            new Job{ApplicantID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, CompanyName ="Jai Khodiyar Inc", CompanyLocation ="13211 Central Ave, ABQ NM",
                Position ="Assistant General Manager", WorkStartDate =DateTime.Parse("05-01-2013"), WorkEndDate = DateTime.Parse("09-16-2018")}

            };

            foreach (Job j in jobs)
            {
                context.Jobs.Add(j);
            }
            context.SaveChanges();

            // Duties are part of Job, so how do I call them here??
            var duties = new Duty[]
            {
            new Duty{ JobID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, DutiesPerformed ="answer phone"}
            };

            foreach (Duty d in duties)
            {
                context.Duties.Add(d);
            }
            context.SaveChanges();

            var references = new Reference[]
            {
            new Reference{ ApplicantID = context.Applicants.FirstOrDefault(y => y.FirstName=="Dipendra").ApplicantID, FirstName ="Jay", LastName = "Shah", PhoneNumber = "505-292-7600"}
            };

            foreach (Reference r in references)
            {
                context.References.Add(r);
            }
            context.SaveChanges();


        }
    }
}
