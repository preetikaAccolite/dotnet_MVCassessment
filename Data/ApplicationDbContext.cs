using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using MVC_assessment.Models;

namespace MVC_assessment.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {



        }
        public DbSet<Category> Employee { get; set; }
        public DbSet<MVC_assessment.Models.ContactUrl> ContactUrl { get; set; } = default!;
    }
}
    
    //    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    //    {
    //         public DbSet<Category> Employee { get; set; }
    //    public DbSet<Category> Employees { get; set; } = default!;
    //}
    //    public DbSet<Category> Employee { get; set; }
    //}
    