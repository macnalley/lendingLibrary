using Microsoft.VisualStudio.TestTools.UnitTesting;
using LendingLibraryWeb.CodeLibraries;
using System.Threading.Tasks;

namespace LendingLibraryTest;

[TestClass]
public class OpenLibraryTests
{
    [TestMethod]
    public async Task GetOpenLibraryBookTestIsbn10()
    {
        string isbn = "0140328726";
        OpenLibraryBook olBook = await OpenLibrary.GetOpenLibraryBookAsync(isbn);

        Assert.AreEqual("Fantastic Mr. Fox", olBook.title);
    }

    [TestMethod]
    public async Task GetOpenLibraryBookTestIsbn13()
    {
        string isbn = "9780140328721";
        OpenLibraryBook olBook = await OpenLibrary.GetOpenLibraryBookAsync(isbn);

        Assert.AreEqual("Fantastic Mr. Fox", olBook.title);
    }

    [TestMethod]
    public async Task GetAuthorTest()
    {
        string isbn = "0140328726";
        OpenLibraryBook olBook = await OpenLibrary.GetOpenLibraryBookAsync(isbn);

        Author author = await OpenLibrary.GetAuthorAsync(olBook);

        Assert.AreEqual("Roald Dahl", author.name);

    }

    // [TestMethod]
    // public void BookMapperTest()
    // {
    // }

    // [TestMethod]
    // public void GetBookTest()
    // {
    // }
}