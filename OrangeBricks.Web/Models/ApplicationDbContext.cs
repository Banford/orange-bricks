using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OrangeBricks.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IOrangeBricksContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Property> Properties { get; set; }
    }

    public interface IOrangeBricksContext
    {
        IDbSet<Property> Properties { get; set; }
    }
}