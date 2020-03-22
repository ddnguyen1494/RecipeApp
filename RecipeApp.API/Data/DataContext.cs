using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeApp.API.Models;

namespace RecipeApp.API.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>(recipe => {
                recipe.Property(p => p.Name).IsRequired();
                
                recipe.Property(p => p.Description).IsRequired();

                recipe.HasMany(r => r.Ingredients)
                    .WithOne()
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Ingredient>(ingredient => {
                ingredient.Property(p => p.Name).IsRequired();
                ingredient.Property(p => p.Amount).IsRequired();
            });
        }
    }
}