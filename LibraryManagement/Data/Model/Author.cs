using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Model
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }

        //Relationship to Book Class
        public virtual ICollection<Book> Books { get; set; }
    }
}
