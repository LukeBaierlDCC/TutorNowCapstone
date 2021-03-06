﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TutorMeNow.Models;

namespace TutorMeNow
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        public int AvgRating { get; set; }
        public int TutorId { get; set; }
        [ForeignKey("TutorId")]
        public virtual Tutor RatedTutor { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student RatedStudent { get; set; }
    }
}