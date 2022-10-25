using System.ComponentModel.DataAnnotations;
using LendingLibraryWeb.Data.Entities;

namespace LendingLibraryWeb.Models;

public class BookModel
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    [Required, StringLength(10)]
    public string Isbn10 { get; set; }
    [Required, StringLength(13)]
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

    public void MapFromBook(Book book)
    {
        Title = book.Title;
        Author = book.Author;
        Isbn10 = book.Isbn10;
        Isbn13 = book.Isbn13;
        IsAvailable = book.IsAvailable;
    }

    public Book MapToBook()
    {
        var book = new Book
        {
            Title = this.Title,
            Author = this.Author,
            Isbn10 = this.Isbn10,
            Isbn13 = this.Isbn13,
            IsAvailable = this.IsAvailable
        };
        
        return book;
    }
}
