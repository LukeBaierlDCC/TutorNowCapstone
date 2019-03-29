using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class Subcategories
    {
        [Key]
        public int SubcatId { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string English { get; set; }
        public string Math { get; set; }
        public string Science { get; set; }
        public virtual ICollection<Subcategories> GetSubcategories { get; set; }
    }

    public enum Subjects
    {
        English,
        Math,
        Science
    }

    public enum EnglishSubcategories
    {
        ArgumentativeWriting,
        CriticalAnalysis,
        EssayWriting,
        Grammar,
        Literature,
        PublicSpeaking

    }

    public enum MathSubcategories
    {
        Arithmetic,
        AlgebraOne,
        AlgebraTwo,
        Calculus,
        Geometry,
        PreAlgebra,
        PreCalculus,
        Statistics,
        Trigonometry
    }

    public enum ScienceSubcategories
    {
        Biology,
        Chemistry,
        Physics
    }

    public class AccessClass
    {
        public Subject Subject { get; set; }
    }
}