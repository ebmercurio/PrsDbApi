using Microsoft.EntityFrameworkCore;
using PrsDbSpecs;
using PrsDbSpecs.Models;

namespace PrsDbApi.Models {
    public class AppDbContext : DbContext {

        public DbSet<PrsDbSpecs.User>? User { get; set; }
        public DbSet<PrsDbSpecs.Models.Vendor>? Vendor { get; set; }
        public DbSet<PrsDbSpecs.Models.Product>? Product { get; set; }
        public DbSet<PrsDbSpecs.Models.Request>? Request { get; set; }
        public DbSet<PrsDbSpecs.Models.RequestLine>? RequestLine { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

    }
}
