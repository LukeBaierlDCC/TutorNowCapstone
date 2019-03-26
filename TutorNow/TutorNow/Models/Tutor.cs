using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorNow.Models
{
    public class Tutor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        //May need Foreign Key UserID.
    }
}