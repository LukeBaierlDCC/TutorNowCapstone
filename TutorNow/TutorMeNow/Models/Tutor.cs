using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class Tutor
    {
        [Key]
        public int TutorId { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public Gender? Gender { get; set; }
        public int AvgRating { get; set; }
        [Required]
        public DateTime PastSession { get; set; }
        [Required]
        [Display(Name = "Subject")]
        public int SubjectId { get; set; }
        [ForeignKey("Subcategory")]
        public string Subcategory { get; set; }

        public virtual Subject SubjectName { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
    
