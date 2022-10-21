using LendingLibraryWeb.CodeLibraries;
using LendingLibraryWeb.Data;
using LendingLibraryWeb.Data.Entities;
using LendingLibraryWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LendingLibraryWeb.Controllers;

public class BookController : Controller
{
    private readonly LibraryContext _context;

    public BookController(LibraryContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // var books = await _context.Books.ToListAsync();
        
        return View();
    }

    public async Task<IActionResult> Add(BookModel model)
    {
        
        
        
        return View();
    }

    public async Task<IActionResult> GetInfoByIsbn(string isbn)
    {        
        try
        {
            if (isbn.Length == 10 || isbn.Length == 13)
            {
                Book book = await OpenLibrary.GetBookByIsbnAsync(isbn);

                BookModel bookModel = book.MaptoBookModel();       
                
                return RedirectToAction("Add", bookModel);
            }
            else 
            {
                var bookModel = new BookModel();
                bookModel.ErrorMessage = "The ISBN must be either 10 or 13 digits.";

                return RedirectToAction("Add", bookModel);
            }
        }
        catch (System.Exception)
        {  
            var bookModel = new BookModel();
            bookModel.ErrorMessage = "No book found.";

            return RedirectToAction("Add", bookModel);;
        }     
    }

    public async Task<IActionResult> Details(int id)
    {
        return View();
    }
}