using LendingLibraryWeb.Data.Entities;

namespace LendingLibraryWeb.Models;

public class BookModel
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Isbn10 { get; set; }
    public int Isbn13 { get; set; }
    public string CoverUrl 
    { 
        get
        {
            return $"https://covers.openlibrary.org/b/isbn/{Isbn13}-M.jpg";
        }
    }
    public bool IsAvailable { get; set; }
    public string? ErrorMessage { get; set; }

    public void Map(Book book)
    {
        Title = book.Title;
        Author = $"{book.AuthorFirstName} {book.AuthorLastName}";
        Isbn10 = book.Isbn10;
        Isbn13 = book.Isbn13;
        IsAvailable = book.IsAvailable;
    }
}
