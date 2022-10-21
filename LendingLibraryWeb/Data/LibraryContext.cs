using Microsoft.EntityFrameworkCore;
using LendingLibraryWeb.Data.Entities;

namespace LendingLibraryWeb.Data;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public LibraryContext() :base()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=Library.db");
    }

}
