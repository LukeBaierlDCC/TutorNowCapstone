using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        public int AvgRating { get; set; }

        public int TutorId { get; set; }
        
        public virtual Tutor RatedTutor { get; set; }
    }
}