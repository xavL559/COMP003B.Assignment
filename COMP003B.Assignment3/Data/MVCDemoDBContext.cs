using COMP003B.Assignment3_.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.Assignment3_.Data
{
    public class MVCDemoDBContext : DbContext
    {
        public MVCDemoDBContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<gadget> Gadgets { get; set; }
    }
}
