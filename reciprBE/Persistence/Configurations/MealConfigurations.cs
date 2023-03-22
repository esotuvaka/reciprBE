using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using reciprBE.Models;  
using System.Text.Json;

namespace reciprBe.Persistence.Configurations;

public class MealConfigurations : IEntityTypeConfiguration<Meal>
{
    // Creating the shape of the Data in the DB
    public void Configure(EntityTypeBuilder<Meal> builder)
    { 
        builder.ToTable("Meals");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .HasColumnName("MealId")
            .ValueGeneratedNever();

        builder.Property(m => m.LastModifiedDateTime)
            .IsRequired();

        builder.Property(m => m.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(m => m.Description)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(m => m.Duration)
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(m => m.Tags)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );

        builder.Property(m => m.Ingredients)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );

        builder.Property(m => m.Seasoning)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );      
    } 
}

 