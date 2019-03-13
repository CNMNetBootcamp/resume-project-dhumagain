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

            //delete first ask question later    *********Add This Once You Add Data********
            //if (context.Students.Any())  

            //{
            //    foreach (var student in context.Students)
            //    {
            //        context.Students.Remove(student);
            //    }

            //    context.SaveChanges();
            //    //now readd the students
            //    AddStudnets(context);

            //}
            //else
            //{
            //    AddStudnets(context);
            //} ****


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
            //    DutiesPerformed ="Assistant General Manager:  Coordinated lodging for clients, assistedclients with transportation and providedother pertinent. " +
            //    "    Trainedand supervisedemployees; taught procedures and provided performance reviews. " +
            //    "    Created official correspondence to clients, as well as all hotel departments. " +
            //    "    Communicated extensively with clients and vendors. " +
            //    "    Set-up and managed direct billing with vendor companies. " +
            //    "    Managed hotel’s reviews, rate information, and Choice Hotel accounts."},


            //new Duty{ JobID = context.Jobs.FirstOrDefault(y => y.CompanyName =="Albuquerque Water Authority").JobID,
            //    DutiesPerformed ="Compliance Division Intern: Sort, categorize, and analyze Water Authority lab samples data. "+
            //    "    Currently creatinga database for past and current samples data."+
            //    "    Monitor well water sites. "+
            //    "    Transcribed customer needs and assisted with customer solutions."}
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
