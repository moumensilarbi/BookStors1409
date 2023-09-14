using bookstore.Models;
using bookstore.Models.Reposotores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Controllers
{
    public class AhthorController : Controller
    {
        private readonly Ibookstorerepo<Author> authorrepo;

        public AhthorController(Ibookstorerepo<Author> authorrepo)
        {
            this.authorrepo = authorrepo;
        }
        // GET: AhthorController
        public ActionResult Index()
        {
            var author = authorrepo.List();

            return View(author);
        }

        // GET: AhthorController/Details/5
        public ActionResult Details(int id)
        {
            var author = authorrepo.Find(id);
            return View(author);
        }

        // GET: AhthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AhthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            try
            {
                authorrepo.add(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AhthorController/Edit/5
        public ActionResult Edit(int id)
        {
            var author = authorrepo.Find(id);
            return View(author);
        }

        // POST: AhthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author author)
        {
            try
            {
                authorrepo.Update(id, author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AhthorController/Delete/5
        public ActionResult Delete(int id)
        {
            var author = authorrepo.Find(id);// authorrepo.Find(id);

            return View(author);
        }

        // POST: AhthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Author author)
        {
            try
            {
                authorrepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
