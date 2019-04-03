﻿using System.ComponentModel.DataAnnotations;

namespace TutorMeNow.Models
{
    public class FieldOfStudy
    {
        [Key]
        public int SubjectId { get; set; }
        public string Subject { get; set; }
        public string English { get; set; }
        public string Math { get; set; }
        public string Science { get; set; }

    }
    public enum Subject
    {
        English,
        Math,
        Science,
        Other
    }
}