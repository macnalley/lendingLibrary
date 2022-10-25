using LendingLibraryWeb.Data.Entities;

namespace LendingLibraryWeb.Data.Repositories;

public interface IBookRepository : IDisposable
{
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book> GetBookByIdAsync(int bookId);
    Task AddBookAsync(Book book);
    Task DeleteBookAsync(int bookId);
    void UpdateBook(Book book);
    Task SaveAsync();
}