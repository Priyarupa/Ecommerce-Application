using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication1.Model;

namespace WebApplication1.DBContext
{
    public class EcommerceDBContext : DbContext
    {

        public EcommerceDBContext(DbContextOptions<EcommerceDBContext> options):base(options)
        {

            

        }
        public DbSet<Login> login { get; set; }
    }
}
