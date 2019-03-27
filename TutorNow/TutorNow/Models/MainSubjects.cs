using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorNow.Models
{
    public class MainSubjects
    {
        public class Subjects
        {
            [Key]
            //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public int CategoryId { get; set; }
            public string name { get; set; }

            public virtual ICollection<StudentProgress> StudentProgresses { get; set; }
        }
    }
}