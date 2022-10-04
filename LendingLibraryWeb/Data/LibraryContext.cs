using Microsoft.EntityFrameworkCore;
using LendingLibraryWeb.Data.Entities;

namespace LendingLibraryWeb.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                        .HasData(new User 
                        { 
                            Id = 1, 
                            Username = "Admin", 
                            Password = "AdminPassword",
                            UserType = UserType.Admin
                        });
         }

        public LibraryContext() :base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=Library.db");
        }

    }
}