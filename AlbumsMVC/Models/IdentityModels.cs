using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AlbumsMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("Data Source=DESKTOP-VHG5P15;Initial Catalog=Albums;Integrated Security=True;Pooling=False", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<AlbumsMVC.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<AlbumsMVC.Models.Author> Authors{ get; set; }

        public System.Data.Entity.DbSet<AlbumsMVC.Models.Genre> Genres { get; set; }
        public System.Data.Entity.DbSet<AlbumsMVC.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<AlbumsMVC.Models.PurchaseData> PurchaseDatas { get; set; }

    }
}