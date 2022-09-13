using Assignment.Model;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Data
{
    public class AssignmentContext:DbContext
    {
        public AssignmentContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<GenerateUrl> generateUrl { get; set; }
    }
}
