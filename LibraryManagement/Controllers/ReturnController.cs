using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class ReturnController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public ReturnController(IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }

        //public IActionResult List()
        //{
        //    Func<Book, bool> myFilter = x => x.BorrowerId != 0;

        //    // Check the books collection
        //    if (!_bookRepository.Any(myFilter))
        //    {
        //        return View("Empty");
        //    }

        //    // load all borrowed books
        //    var borrowedBooks = _bookRepository.FindWithAuthorAndBorrower(myFilter);

        //    return View(borrowedBooks);
        //}
        [Route("Return")]
        public IActionResult List()
        {
            var borrowedBooks = _bookRepository.FindWithAuthorAndBorrower(x => x.BorrowerId != 0);

            // Check the books collection
            if (borrowedBooks == null || !borrowedBooks.ToList().Any())
            {
                return View("Empty");
            }

            // load all borrowed books
            //var borrowedBooks = _bookRepository.FindWithAuthorAndBorrower(myFilter);

            return View(borrowedBooks);
        }

        public IActionResult ReturnABook(int bookId)
        {
            var book = _bookRepository.GetById(bookId);

            book.Borrower = null;

            book.BorrowerId = 0;

            _bookRepository.Update(book);

            return RedirectToAction("List");
        }
    }
}