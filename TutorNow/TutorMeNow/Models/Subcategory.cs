using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TutorMeNow.Models
{
    public class Subcategory
    {
        [Key]
        public int SubcategoryId { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string English { get; set; }
        public string Math { get; set; }
        public string Science { get; set; }
        public virtual ICollection<Subcategory> GetSubcategory { get; set; }
    }

    public enum Subjects
    {
        English,
        Math,
        Science
    }

    public enum EnglishSubcategory
    {
        ArgumentativeWriting,
        CriticalAnalysis,
        EssayWriting,
        Grammar,
        Literature,
        PublicSpeaking

    }

    public enum MathSubcategory
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

    public enum ScienceSubcategory
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