using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models.Reposotores
{
    public class BookDBrepository : Ibookstorerepo<Book>
    {
        BookstoreDBContext db;
        public BookDBrepository(BookstoreDBContext _db)
        {
            db = _db;
        }

        public void add(Book entety)
        {
            
            db.Books.Add(entety);
            commit(); 
        }

        public void Delete(int id)
        {
            var book = Find(id);
            db.Books.Remove(book);
            commit();
        }

        public Book Find(int id)
        {
            var book = db.Books.Include(a => a.author).SingleOrDefault(b => b.Id == id);
            return book;
        }

        public IList<Book> List()
        {
            return db.Books.Include(a=> a.author).ToList();
        }

        public void Update(int id, Book newbook)
        {
            db.Update(newbook);
            commit();

        }
        public void commit()
        { db.SaveChanges(); }
    }
}
