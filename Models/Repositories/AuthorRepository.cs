using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreApp.Models.Repositories
{
    //We use IRespo<Auhtor> instead of AuthorRespository to use Loose Coupling
    public class AuthorRepository:IRepo<Author>
    {
        List<Author> authors;

        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author{Id=1,Name="Khalid Essadani"},
                new Author{Id=2,Name="Mouad Sbayli"},
                new Author{Id=3,Name="Marwane Bidamou"},
                new Author{Id=4,Name="Mohamed Ali"},
                new Author{Id=5,Name="Yassine Reda"},
                new Author{Id=6,Name="Ismail Alaoui"}
            };
        }

        public void Add(Author author)
        {
            authors.Add(author);
        }

        public int Commit()
        {
            return 1;
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

      

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(a => a.Id == id);
            return author;
        }

        public List<Author> GetAll()
        {
            return authors;
        }

        public void Update(Author t)
        {
            var oldAuthor = Find(t.Id);
            oldAuthor.Name = t.Name;
        }
    }
}
