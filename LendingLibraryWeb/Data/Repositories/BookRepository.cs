using LendingLibraryWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LendingLibraryWeb.Data.Repositories;

public class BookRepository : IBookRepository, IDisposable
{
    private LibraryContext _context;
    private bool _disposed = false;

    public BookRepository (LibraryContext context)
    {
        _context = context;
    }

    public async Task AddBookAsync(Book book)
    {
        await _context.Books.AddAsync(book);
    }

    public async Task DeleteBookAsync(int bookId)
    {
        Book book = await _context.Books.FindAsync(bookId);
        _context.Books.Remove(book);
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _context.Dispose();
        }
        _disposed = true;
    }

    public async Task<Book> GetBookByIdAsync(int bookId)
    {
        return await _context.Books.FindAsync(bookId);
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void UpdateBook(Book book)
    {
        _context.Entry(book).State = EntityState.Modified;
    }
}