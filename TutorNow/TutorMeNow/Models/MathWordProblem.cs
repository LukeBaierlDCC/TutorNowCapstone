using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class MathWordProblem
    {
        [Key]
        public int MathId { get; set; }
        public string MathQuestion { get; set; }
        public string MathAnswer { get; set; }
    }
}