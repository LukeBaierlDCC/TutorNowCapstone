using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("name=StudentContext")
        {

        }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Student> students { get; set; }
    }
}