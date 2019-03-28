using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TutorNow.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
        
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Tutor> tutors { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<MainSubjects> mainSubjects { get; set; }
        public DbSet<StudentProgress> studentProgresses { get; set; }
        public DbSet<Ratings> ratings { get; set; }
    }
}