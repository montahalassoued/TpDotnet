using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Many-to-One Movie +Genre
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Genre)
            .WithMany(g => g.Movies)
            .HasForeignKey(m => m.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
        // Customer → MembershipType (Many-to-One)
        modelBuilder.Entity<Customer>()
        .HasOne(c => c.MembershipType)
        .WithMany(mt => mt.Customers)
        .HasForeignKey(c => c.MembershipTypeId)
        .OnDelete(DeleteBehavior.Restrict);
        // Customer ↔ Movie (Many-to-Many)
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Movies)
            .WithMany(m => m.Customers)
            .UsingEntity(j => j.ToTable("CustomerMovies"));
        // Données
            DbSeeder.Seed(modelBuilder);

    }
}