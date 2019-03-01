using Microsoft.EntityFrameworkCore;
using ResumeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeProject.Data
{
   public class ResumeContext : DbContext
    {
        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<Reference> References  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>().ToTable("Applicant");
            modelBuilder.Entity<Education>().ToTable("Education");
            modelBuilder.Entity<Job>().ToTable("Job");
            modelBuilder.Entity<Duty>().ToTable("Duty");
            modelBuilder.Entity<Reference>().ToTable("Reference");

        }

    }
}
