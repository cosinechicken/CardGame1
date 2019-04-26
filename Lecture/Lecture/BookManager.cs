using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public class BookManager
    {
        public static List<Book> GetBooks()
        {
            var books = new List<Book>();

            books.Add(new Book { BookId = 1, Title = "Vulpate", Author = "Futurum", CoverImage = "Assets/1.png" });
            books.Add(new Book { BookId = 2, Title = "Mazia", Author = "Sequiter Que", CoverImage = "Assets/2.png" });
            books.Add(new Book { BookId = 3, Title = "Elit", Author = "Tempor", CoverImage = "Assets/3.png" });

            return books;
        }
    }
}
