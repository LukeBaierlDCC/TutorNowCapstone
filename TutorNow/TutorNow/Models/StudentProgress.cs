using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorNow.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class StudentProgress
    {
        public int StudentProgressID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Student Student { get; set; }
    }
}