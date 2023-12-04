using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using MiniStore.Models;

namespace MiniStore.Context
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions opt) : base(opt) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
