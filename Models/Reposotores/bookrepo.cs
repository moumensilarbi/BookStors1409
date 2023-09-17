using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models.Reposotores
{
    public class bookrepo : Ibookstorerepo<Book>
    {
        List<Book> books;
        public bookrepo()
        {
            books = new List<Book>
            {
            new Book
            {
                Id=1, Title="c#",
                Descreption="d1" , 
                ImageUrl = "4.png",
                author = new Author{ Id=2}
            },
            new Book
            {
                Id=2, Title="JAva",
                Descreption="d1",
                 ImageUrl = "5.png",
                author = new Author()
            }
            };

        }

        public void add(Book entety)
        {
            entety.Id = books.Max(b=> b.Id)+1;
            books.Add(entety);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(b => b.Id == id);
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public void Update(int id,Book newbook)
        {
            var book = Find(id); 
            book.Title = newbook.Title;
            book.Descreption = newbook.Descreption;
            book.author = newbook.author;
            book.ImageUrl = newbook.ImageUrl;

        }
    }
}
