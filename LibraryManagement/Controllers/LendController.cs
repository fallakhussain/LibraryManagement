using LibraryManagement.Data.Interfaces;
using LibraryManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class LendController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public LendController(IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }

        [Route("Lend")]
        public IActionResult List()
        {
            //We need to first load all the available books
            //We find the books with author that have no borrowers
            var availableBooks = _bookRepository.FindWithAuthor(x => x.BorrowerId == 0);

            //Check collection
            if (!availableBooks.Any())
            {
                return View("Empty");
            }
            else
            {
                return View(availableBooks);
            }
        }

        //
        public IActionResult LendBook(int id)
        {
            //Load current book and all customers
            //In order to send data to the Lend view we need a ViewModel Class
            var lendVM = new LendViewModel()
            {
                Book = _bookRepository.GetById(id),
                Customers = _customerRepository.GetAll()
            };

            //Send the data to the lend view
            return View(lendVM);
        }

        [HttpPost]
        public IActionResult LendBook(LendViewModel lendViewModel)
        {
            // Update the database
            var book = _bookRepository.GetById(lendViewModel.Book.BookID);
            var customer = _customerRepository.GetById(lendViewModel.Book.BorrowerId);

            book.Borrower = customer;

            // Redirect to the list view
            return RedirectToAction("List");
        }


    }
}
