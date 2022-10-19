using Microsoft.VisualStudio.TestTools.UnitTesting;
using LendingLibraryWeb.CodeLibraries;
using System.Threading.Tasks;
using System.Collections.Generic;
using LendingLibraryWeb.Data.Entities;

namespace LendingLibraryTest;

[TestClass]
public class OpenLibraryTests
{
    private string _isbn10 = "0140328726";
    private string _isbn13 = "9780140328721";


    [TestMethod]
    public async Task GetOpenLibraryBookTestIsbn10()
    {
        OpenLibraryBook olBook = await OpenLibrary.GetOpenLibraryBookAsync(_isbn10);

        Assert.AreEqual("Fantastic Mr. Fox", olBook.title);
    }

    [TestMethod]
    public async Task GetOpenLibraryBookTestIsbn13()
    {
        OpenLibraryBook olBook = await OpenLibrary.GetOpenLibraryBookAsync(_isbn13);

        Assert.AreEqual("Fantastic Mr. Fox", olBook.title);
    }

    [TestMethod]
    public async Task GetAuthorTest()
    {
        
        // Arranging mock book with Roald Dahl's key.
        var olBook = new OpenLibraryBook
        {
            authors = new List<Author>
            {
                new Author { key = "/authors/OL34184A" }
            }
        };

        // Act
        Author author = await OpenLibrary.GetAuthorAsync(olBook);

        // Assert
        Assert.AreEqual("Roald Dahl", author.name);

    }

    [TestMethod]
    public async Task GetBookTest()
    {        
        Book book = await OpenLibrary.GetBookByIsbnAsync(_isbn10);

        Assert.AreEqual("Fantastic Mr. Fox", book.Title);
        Assert.AreEqual("Roald Dahl", book.Author);
        Assert.AreEqual(_isbn10, book.Isbn10);
        Assert.AreEqual(_isbn13, book.Isbn13);
    }
}