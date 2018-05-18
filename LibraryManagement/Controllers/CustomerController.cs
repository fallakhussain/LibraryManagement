using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Data.Interfaces;
using LibraryManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookRepository _bookRepository;

        public CustomerController(ICustomerRepository customerRepository, IBookRepository bookRepository)
        {
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        [Route("Customer")]
        public IActionResult List()
        {
            //First create list of customer view model
            var customerVM = new List<CustomerViewModel>();

            var customers = _customerRepository.GetAll();

            if (!customers.Any())
            {
                return View("Empty");
            }

            foreach (var customer in customers)
            {
                customerVM.Add(new CustomerViewModel
                {
                    Customer = customer,
                    BookCount = _bookRepository.Count(x => x.BorrowerId == customer.CustomerID)
                });
            }

            return View(customerVM);
        }
    }
}
