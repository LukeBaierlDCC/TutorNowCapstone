using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class RatingView
    { 
        [Key]
        public int Id { get; set; }
        public Rating Rating { get; set; }
        public Tutor Tutor { get; set; }
        public States State { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}