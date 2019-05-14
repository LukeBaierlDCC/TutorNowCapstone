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
        public int SubjectId { get; set; }
        //[ForeignKey("SubjectId")]
        public int SubcategoryId { get; set; }
        public string FieldOfStudy { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Subcategory> GetSubcategory { get; set; }
    }

    public class AccessClass
    {
        public Subject Subject { get; set; }
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

}