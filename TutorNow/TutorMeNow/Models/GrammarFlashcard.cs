using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class GrammarFlashcard
    {
        [Key]
        public int GrammarId { get; set; }
        public string GrammarQuestion { get; set; }
        public string GrammarAnswer { get; set; }
    }
}