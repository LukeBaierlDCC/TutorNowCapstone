using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TutorNow.Models;

namespace TutorNow.DataAccess
{
    public class Subcategories : DropCreateDatabaseIfModelChanges<SubcategoriesContext>
    {
        protected override void Seed(SubcategoriesContext context)
        {
            
        }
    }
}