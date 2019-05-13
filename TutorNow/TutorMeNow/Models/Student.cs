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
        public States State { get; set; }
        public int ZipCode { get; set; }
        public Gender Gender { get; set; }
        public string LearningGoal { get; set; }

        public enum StudentGender
        {
            Male,
            Female
        }

        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public FieldOfStudy Subject { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public Subject SubjectName { get; set; }

        public Subcategory Subcategory { get; set; }

        public class AccessClass
        {
            public Subject Subject { get; set; }
        }

        [Required]
        public DateTime PastSession { get; set; }
        [Required]
        public int AvgRating { get; set; }
        //public virtual ICollection<Subject> Subject { get; set; }
        public List<Subcategory> Subcategories { get; set; }

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
        public string FieldOfStudy { get; set; }

    }
}