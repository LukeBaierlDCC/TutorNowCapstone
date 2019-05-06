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
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public States State { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        [Required]
        public int AvgRating { get; set; }
        [Required]
        public DateTime PastSession { get; set; }
        [Required]
        public DateTime TutorAvailability { get; set; }

        public int SubjectId { get; set; }
        [ForeignKey("Subcategory")]
        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }

        public int SubcatId { get; set; }
        [ForeignKey("SubcatId")]
        public virtual Tutor Tutors { get; set; }
        public virtual Subject SubjectName { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
    
