using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TutorNow.Models;

namespace TutorNow.DataAccess
{
    public class SubcategoriesContext : DbContext
    {
        public SubcategoriesContext() : base("SubcategoriesContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentProgress> StudentProgresses { get; set; }
        public DbSet<MainSubjects> MainSubjects { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}