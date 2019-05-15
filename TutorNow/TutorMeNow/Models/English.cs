using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class English
    {
        [Key]
        public int EnglishId { get; set; }
        public string EnglishSubcategory { get; set; }
        public string EnglishTutor { get; set; }
        public string EnglishStudent { get; set; }
    }
}