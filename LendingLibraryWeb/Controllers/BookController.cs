using LendingLibraryWeb.CodeLibraries;
using LendingLibraryWeb.Data;
using LendingLibraryWeb.Data.Entities;
using LendingLibraryWeb.Data.Repositories;
using LendingLibraryWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LendingLibraryWeb.Controllers;

public class BookController : Controller
{
    private readonly IBookRepository _bookRepository;

    public BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _bookRepository.GetBooksAsync();

        return View(books);
    }

    public async Task<IActionResult> Add()
    {      
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(BookModel model)
    {      
        if (ModelState.IsValid)
            {
                Book book = model.MapToBook();

               await _bookRepository.AddBookAsync(book);
               await _bookRepository.SaveAsync();
               return RedirectToAction("Index");
            }

            return View(model);

    }

    public async Task<IActionResult> Details(int id)
    {
        Book book = await _bookRepository.GetBookByIdAsync(id);
        
        return View(book);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _bookRepository.DeleteBookAsync(id);
        await _bookRepository.SaveAsync();

        return RedirectToAction("Index");
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
}