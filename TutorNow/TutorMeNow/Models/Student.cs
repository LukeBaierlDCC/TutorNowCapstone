﻿using System;
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
        //[ForeignKeyAttribute("ApplicationUser")]
        //public string ApplicationUserId { get; set; }
    }
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        [Display(Name = "Course Subject")]
        public string SubjectName { get; set; }
    }
}