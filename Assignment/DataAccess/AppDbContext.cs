using Microsoft.EntityFrameworkCore;
using Assignment.Core.Domain;

namespace Assignment.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            /*
                Tried to use commented code below to disable lazy loading but
                I suspect the code below is for the legacy ASP.NET Framework 
                while my mini assignment project was created with ASP.NET Core.
                Of course if I am not mistaken, this would have disabled lazy 
                loading across the entire project which is likely not a good
                approach to take since at times for performance reasons you
                want lazy loading to be enabled for some entity relationships
                while at other times you need eager or explicit loading.

                this.Configuration.LazyLoadingEnabled = false;
            */
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }
    }
}
