using EVENTS.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EVENTS.Data
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)

        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event>()
                .HasOne(p => p.Photoalbum)
                .WithOne(E => E._Event)
                .HasForeignKey<album>(p => p.EventId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Source>()
                .HasMany(b => b.Events)
                .WithOne()
                .HasForeignKey(b => b.EventId)
                .HasPrincipalKey(v=>v.SourceId)
                .OnDelete(DeleteBehavior.Restrict);

            //.HasForeignKey<>
            modelBuilder.Entity<Event>()
                .HasMany(x => x.Categories)
                .WithMany(t => t._Events)
                .UsingEntity(j => j.ToTable("Categories"));
                //.OnDelete(DeleteBehavior.Restrict);



        }
        public DbSet<Event> Events { get; set; }
        public DbSet<album> albums { get; set; }
        public DbSet<Source> _Sources { get; set; }
        public DbSet<Category> Categories { get; set; }

       







    }
}
