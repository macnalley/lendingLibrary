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
        int isbn = 0140328726;
        OpenLibraryBook olBook = await OpenLibrary.GetOpenLibraryBookAsync(isbn);

        Assert.AreEqual("Fantastic Mr. Fox", olBook.title);

    }

    // public void GetOpenLibraryBookTestIsbn13()
    // {
    // }

    // [TestMethod]
    // public void GetAuthorTest()
    // {
    // }

    // [TestMethod]
    // public void BookMapperTest()
    // {
    // }

    // [TestMethod]
    // public void GetBookTest()
    // {
    // }
}