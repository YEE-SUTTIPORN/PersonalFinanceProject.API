using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceProjects.API.Models;

namespace PersonalFinanceProjects.API.Database
{
    public class PersonalFinanceDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<TransactionImageModel> TransactionImages { get; set; }

        public PersonalFinanceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TransactionModel>()
            .Property(t => t.Amount)
            .HasPrecision(18, 4);

            modelBuilder.Entity<TransactionModel>()
            .HasOne(t => t.User)
            .WithMany(u => u.Transactions)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TransactionModel>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TransactionImageModel>()
                .HasOne(ti => ti.Transaction)
                .WithMany(t => t.TransactionImages)
                .HasForeignKey(ti => ti.TransactionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
