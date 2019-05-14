using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class Science
    {
        [Key]
        public int ScienceId { get; set; }
        public string ScienceSubcategory { get; set; }
    }
}