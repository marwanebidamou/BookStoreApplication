using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreApp.Models.Repositories
{
    public class DbAuthorRepository: IRepo<Author>
    {
        private readonly BookStoreDbContext context;

        public DbAuthorRepository(BookStoreDbContext context)
        {
            this.context = context;
        }

        public void Add(Author author)
        {
            context.Authors.Add(author);
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = Find(id);
            context.Authors.Remove(author);
        }



        public Author Find(int id)
        {
            var author = context.Authors.SingleOrDefault(a => a.Id == id);
            return author;
        }

        public List<Author> GetAll()
        {
            return context.Authors.ToList();
        }

        public void Update(Author t)
        {
            //Attach or Update
            context.Authors.Update(t);            
        }
    }
}
