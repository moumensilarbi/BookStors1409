using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models.Reposotores
{
    public class Ahthorrepo : Ibookstorerepo<Author>
    {
        IList<Author> ahthors;
        public Ahthorrepo()
        {
            ahthors = new List<Author>
                {
                new Author { Id=1,FullName="moumen"},
                new Author { Id=2,FullName="larbi"},
                new Author { Id=3,FullName="silarbi"}
                };
        }
        
        public void add(Author entety)
        {
            entety.Id = ahthors.Max(b=> b.Id) + 1;
            ahthors.Add(entety);
        }

        public void Delete(int id)
        {
            var ahthor = Find(id);

            ahthors.Remove(ahthor);
        }

        public Author Find(int id)
        {
            var ahthor = ahthors.FirstOrDefault(a=> a.Id== id);
            return ahthor;
        }

        public IList<Author> List()
        {
            return ahthors;
        }

        public void Update(int id, Author newahthor)
        {
            var ahthor = Find(id);
            ahthor.FullName = newahthor.FullName;
        }
    }
}
