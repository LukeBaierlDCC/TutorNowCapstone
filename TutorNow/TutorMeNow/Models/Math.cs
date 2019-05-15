using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class Math
    {
        [Key]
        public int MathId { get; set; }
        public string MathSubcategory { get; set; }
        public string MathTutor { get; set; }
        public string MathStudent { get; set; }
    }
}