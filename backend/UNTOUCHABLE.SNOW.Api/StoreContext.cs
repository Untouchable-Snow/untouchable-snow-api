using Untouchable.Snow.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Untouchable.Snow.Data
{
    public class StoreContext : DbContext
    {
        public Storecontext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }
    }
}