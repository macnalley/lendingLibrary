using LendingLibraryWeb.CodeLibraries;
using LendingLibraryWeb.Models;

namespace LendingLibraryWeb.Data.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn10 { get; set; }
    public string Isbn13 { get; set; }
    public bool IsAvailable { get; set; } = true;

    public BookModel MaptoBookModel()
    {
        var bookModel = new BookModel();

        bookModel.Title = Title;
        bookModel.Author = Author;
        bookModel.Isbn10 = Isbn10;
        bookModel.Isbn13 = Isbn13;
        bookModel.IsAvailable = IsAvailable;

        return bookModel;
    }
}
