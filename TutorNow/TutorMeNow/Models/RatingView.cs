using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class RatingView
    {
        public Rating Rating { get; set; }
        public Tutor Tutor { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}