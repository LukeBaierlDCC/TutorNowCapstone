using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class Subcategories
    {
        [Key]
        public int SubcatId { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; }
    }

    public enum Subjects
    {
        English,
        Math,
        Science
    }
    public class AccessClass
    {
        public Subject Subject { get; set; }
    }
}