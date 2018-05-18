using LibraryManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Interfaces
{
    public interface IBookRepository
    {
        //Get all books with author
        IEnumerable<Book> GetAllWithAuthor();
        //Find a book with author
        IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate);
        //Find a book with author and borrower
        IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate);
    }
}
