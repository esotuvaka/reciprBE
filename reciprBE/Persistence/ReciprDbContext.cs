using Microsoft.EntityFrameworkCore;
using reciprBE.Models;

namespace reciprBE.Persistence; 

public class ReciprDbContext : DbContext {
    public ReciprDbContext(DbContextOptions<ReciprDbContext> options) 
        : base(options) 
    {
    } 

    public DbSet<Meal> Meals { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReciprDbContext).Assembly);
    }
}