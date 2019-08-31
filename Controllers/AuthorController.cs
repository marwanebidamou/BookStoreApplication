using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookstoreApp.Models;
using BookstoreApp.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IRepo<Author> repo;

        public AuthorController(IRepo<Author> repo)
        {
            this.repo = repo;
        }
        // GET: Author
        public ActionResult Index()
        {
            var authors = repo.GetAll();
            return View(authors);
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            var author = repo.Find(id);
            return View(author);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author a)
        {
            try
            {
                // TODO: Add insert logic here
                repo.Add(a);
                repo.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            var author = repo.Find(id);
            return View(author);
        }

        // POST: Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author a)
        {
            try
            {
                repo.Update(a);
                repo.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            var author = repo.Find(id);
            return View(author);
        }

        // POST: Author/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                repo.Delete(id);
                repo.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string term)
        {
            if (string.IsNullOrEmpty(term))
                return View("Index", repo.GetAll());

            var authors = repo.GetAll().Where(x => x.Name.ToLower().Contains(term.ToLower()));
            return View("Index", authors);
        }
    }
}