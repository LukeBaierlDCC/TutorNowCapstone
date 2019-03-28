using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class StudentProgress
    {
        [Key]
        public int StudentProgressID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Student Student { get; set; }
    }
}