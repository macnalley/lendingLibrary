using LendingLibraryWeb.Data;
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
        var books = await _context.Books.ToListAsync();
        
        return View(books);
    }

    public async Task<IActionResult> Add(BookModel model)
    {
        
        
        
        return RedirectToAction("Details");
    }

    public async Task<IActionResult> AddByIsbn(int isbn)
    {
        if (isbn.ToString().Length == 10 || isbn.ToString().Length == 13)
        {
            
            
            
            
            
            return RedirectToAction("Add");
        }
        else 
        {
            var bookModel = new BookModel();
            bookModel.ErrorMessage = "The ISBN must be either 10 or 13 digits.";

            return View(bookModel);
        }
        
        
        
    }

    public async Task<IActionResult> Details(int id)
    {
        return View();
    }
}