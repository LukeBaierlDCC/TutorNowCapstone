using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TutorNow.Models
{
    public class Tutor
    {
        [Key]
        public int TutorId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public int AvgRating { get; set; }
        [ForeignKeyAttribute("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        //May need Foreign Key UserID.
        public virtual ICollection<Subjects> Subjects { get; set; }
    }
}