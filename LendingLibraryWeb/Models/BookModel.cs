using System.ComponentModel.DataAnnotations;
using LendingLibraryWeb.Data.Entities;

namespace LendingLibraryWeb.Models;

public class BookModel
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    public string Isbn10 { get; set; }
    [Required]
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

    public void MapToBook(Book book)
    {
        Title = book.Title;
        Author = book.Author;
        Isbn10 = book.Isbn10;
        Isbn13 = book.Isbn13;
        IsAvailable = book.IsAvailable;
    }
}
