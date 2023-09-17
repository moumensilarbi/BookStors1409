using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models.Reposotores
{
    public class AhthorDBrepo : Ibookstorerepo<Author>
    {
        BookstoreDBContext db;
        public AhthorDBrepo(BookstoreDBContext _db)
        {
            db = _db;
        }

        public void add(Author entety)
        {
          //  entety.Id = db.Authors.Max(b => b.Id) + 1;
            db.Authors.Add(entety);
            commit();
        }

        public void Delete(int id)
        {
            var ahthor = Find(id);

            db.Authors.Remove(ahthor);
            commit();
        }

        public Author Find(int id)
        {
            var ahthor = db.Authors.FirstOrDefault(a => a.Id == id);
            return ahthor;
        }

        public IList<Author> List()
        {
            return db.Authors.ToList();
        }

        public void Update(int id, Author newahthor)
        {
            db.Update(newahthor);
            commit();
        }
        public void commit()
        { db.SaveChanges(); }
    }
}
