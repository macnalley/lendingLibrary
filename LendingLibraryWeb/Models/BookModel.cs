using LendingLibraryWeb.Data.Entities;

namespace LendingLibraryWeb.Models;

public class BookModel
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn10 { get; set; }
    public string Isbn13 { get; set; }
    public string CoverUrl 
    { 
        get
        {
            return $"https://covers.openlibrary.org/b/isbn/{Isbn13}-M.jpg";
        }
    }
    public bool IsAvailable { get; set; }
    public string? ErrorMessage { get; set; }
}
