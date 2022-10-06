using LendingLibraryWeb.Data.Entities;

namespace LendingLibraryWeb.CodeLibraries;

public static class OpenLibrary
{
    public static async Task<Book> GetBookByISBN(int isbn)
    {
        var client = new HttpClient();

        string response = await client.GetStringAsync($"https://openlibrary.org/isbn/{isbn}.json");

        

        Book book = new Book();

        return book;
    }
}