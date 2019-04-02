using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public enum Gender { Male,Female }
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
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
        [Required]
        [Display(Name = "Subject")]
        public int SubjectId { get; set; }
        public virtual Subject SubjectName { get; set; }
        public virtual ICollection<Subject> Subject { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
    public class SubjectField
    {
        //I should have created a separate class for this instead of adding it here. Followed this video a little too closely: https://www.youtube.com/watch?v=RFQlwIvvS-M&t=511s
        [Key]
        public int SubjectId { get; set; }
        [Required]
        [Display(Name = "Course Subject")]
        public string SubjectName { get; set; }
    }
}