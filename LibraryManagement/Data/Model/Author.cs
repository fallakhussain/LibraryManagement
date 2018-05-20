using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Model
{
    public class Author
    {
        public int AuthorID { get; set; }
        [Required, MinLength(3), MaxLength(60)]
        public string Name { get; set; }

        //Relationship to Book Class
        public virtual ICollection<Book> Books { get; set; }
    }
}
