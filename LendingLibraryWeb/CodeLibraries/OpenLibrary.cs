using LendingLibraryWeb.Data.Entities;
using System.Text.Json;
using System.Net;
using System.Text;

namespace LendingLibraryWeb.CodeLibraries;

public static class OpenLibrary
{
    public static async Task<Book> GetBookByIsbnAsync(string isbn)
    {       
        var openLibraryBook = await GetOpenLibraryBookAsync(isbn);

        var author = await GetAuthorAsync(openLibraryBook);
        
        var book = new Book();

        MapToBook(book, openLibraryBook, author);

        return book;
    }

    public static async Task<OpenLibraryBook>GetOpenLibraryBookAsync(string isbn)
    {
        var sb = new StringBuilder();
        
        using (var client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync($"https://openlibrary.org/isbn/{isbn}.json");
            
            if (response.StatusCode == HttpStatusCode.OK)
            {
                sb.Append(await response.Content.ReadAsStringAsync());
            }
            else if (response.StatusCode == HttpStatusCode.Found)
            {
                string redirect = response.Headers.Location.ToString();
            
                response = await client.GetAsync(redirect);

                sb.Append(await response.Content.ReadAsStringAsync());
            }
        }

        string bookJson = sb.ToString();

        OpenLibraryBook openLibraryBook = JsonSerializer.Deserialize<OpenLibraryBook>(bookJson);

        return openLibraryBook;
    }

    public static async Task<Author> GetAuthorAsync(OpenLibraryBook openLibraryBook)
    {
        string key = openLibraryBook.authors[0].key;
        
        var client = new HttpClient();

        string response = await client.GetStringAsync($"https://openlibrary.org/{key}.json");

        Author author = JsonSerializer.Deserialize<Author>(response);

        return author;
    }

    public static void MapToBook(Book book, OpenLibraryBook openLibraryBook, Author author)
    {
        book.Title = openLibraryBook.title;
        book.Author = author.name;
        book.Isbn10 = openLibraryBook.isbn_10[0];
        book.Isbn13 = openLibraryBook.isbn_13[0];
    }

    public class Author
    {
        public RemoteIds remote_ids { get; set; }
        public string personal_name { get; set; }
        public string bio { get; set; }
        public List<int> photos { get; set; }
        public List<string> source_records { get; set; }
        public Type type { get; set; }
        public string key { get; set; }
        public List<Link> links { get; set; }
        public string name { get; set; }
        public string death_date { get; set; }
        public string birth_date { get; set; }
        public List<string> alternate_names { get; set; }
        public int latest_revision { get; set; }
        public int revision { get; set; }
        public Created created { get; set; }
        public LastModified last_modified { get; set; }
       
        public class RemoteIds
        {
            public string wikidata { get; set; }
            public string isni { get; set; }
            public string viaf { get; set; }
        } 

        public class Link
        {
            public string title { get; set; }
            public string url { get; set; }
            public Type type { get; set; }
        }   
    }

    public class OpenLibraryBook
    {
        public List<string> publishers { get; set; }
        public int number_of_pages { get; set; }
        public List<string> isbn_10 { get; set; }
        public List<int> covers { get; set; }
        public string key { get; set; }
        public List<Author> authors { get; set; }
        public string ocaid { get; set; }
        public List<string> contributions { get; set; }
        public List<Language> languages { get; set; }
        public Classifications classifications { get; set; }
        public List<string> source_records { get; set; }
        public string title { get; set; }
        public Identifiers identifiers { get; set; }
        public List<string> isbn_13 { get; set; }
        public List<string> local_id { get; set; }
        public string publish_date { get; set; }
        public List<Work> works { get; set; }
        public Type type { get; set; }
        public FirstSentence first_sentence { get; set; }
        public int latest_revision { get; set; }
        public int revision { get; set; }
        public Created created { get; set; }
        public LastModified last_modified { get; set; }

        public class Type
        {
            public string key { get; set; }
        }

        public class Work
        {
            public string key { get; set; }
        }
    
        public class FirstSentence
        {
            public string type { get; set; }
            public string value { get; set; }
        }

        public class Classifications
        {
        }

        public class Identifiers
        {
            public List<string> goodreads { get; set; }
            public List<string> librarything { get; set; }
        }     
    
        public class Language
        {
            public string key { get; set; }
        }
    }

    public class Created
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class LastModified
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

}