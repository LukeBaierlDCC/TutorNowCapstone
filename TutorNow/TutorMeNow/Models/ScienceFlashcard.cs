using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class ScienceFlashcard
    {
        [Key]
        public int ScienceId { get; set; }
        public string ScienceQuestion { get; set; }
        public string ScienceAnswer { get; set; }
    }
}