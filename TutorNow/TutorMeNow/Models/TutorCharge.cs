using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class TutorCharge
    {
        [Required]
        public DateTime TutorAvailability { get; set; }

        [Required]
        public decimal TutorFee { get; set; }
    }
}