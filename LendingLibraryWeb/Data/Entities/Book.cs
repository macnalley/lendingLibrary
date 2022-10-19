using LendingLibraryWeb.CodeLibraries;

namespace LendingLibraryWeb.Data.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn10 { get; set; }
    public string Isbn13 { get; set; }
    public bool IsAvailable { get; set; } = true;
}
