namespace LendingLibraryWeb.Data.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorLastName { get; set; }
    public int Isbn10 { get; set; }
    public int Isbn13 { get; set; }
    public bool IsAvailable { get; set; } = true;
}
