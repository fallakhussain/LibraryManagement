using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [Route("Author")]
        public IActionResult List()
        {
            var authors = _authorRepository.GetAllWithBooks();

            if (!authors.Any()) return View("Empty");
            return View(authors);
        }

        //Update view
        public IActionResult Update(int id)
        {
            var author = _authorRepository.GetById(id);
            if (author == null) return NotFound();

            return View(author);
        }

        //Update the author
        [HttpPost]
        public IActionResult Update(Author author)
        {
            _authorRepository.Update(author);
            return RedirectToAction("List");
        }

        //Create view
        public IActionResult Create()
        {
            return View();
        }

        //Create POST
        [HttpPost]
        public IActionResult Create(Author author)
        {
            _authorRepository.Create(author);

            return RedirectToAction("List");
        }

        //Delete
        public IActionResult Delete(int id)
        {
            var author = _authorRepository.GetById(id);
            _authorRepository.Delete(author);

            return RedirectToAction("List");
        }
    }
}
