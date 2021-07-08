using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UserIdentity.Models
{
   
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<UserIdentity.Models.Trainee> Trainees { get; set; }

        public System.Data.Entity.DbSet<UserIdentity.Models.Trainer> Trainers { get; set; }

        public System.Data.Entity.DbSet<UserIdentity.Models.Topic> Topics { get; set; }

        public System.Data.Entity.DbSet<UserIdentity.Models.Term> Terms { get; set; }

        public System.Data.Entity.DbSet<UserIdentity.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<UserIdentity.Models.Session> Sessions { get; set; }

        public System.Data.Entity.DbSet<UserIdentity.Models.Staff> Staffs { get; set; }

        public System.Data.Entity.DbSet<UserIdentity.Models.Admin> Admins { get; set; }

        public System.Data.Entity.DbSet<UserIdentity.Models.TraineeAsign> TraineeAsigns { get; set; }

        public System.Data.Entity.DbSet<UserIdentity.Models.TrainerAsign> TrainerAsigns { get; set; }
    }
}