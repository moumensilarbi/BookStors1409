using bookstore.Models;
using bookstore.Models.Reposotores;
using bookstore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly Ibookstorerepo<Book> bookreposotory;
        private readonly Ibookstorerepo<Author> authorreposotory;
        private readonly IHostingEnvironment hosting;

        public BookController(Ibookstorerepo<Book> bookreposotory, Ibookstorerepo<Author> authorreposotory,
            IHostingEnvironment hosting)
        {
            this.bookreposotory = bookreposotory;
            this.authorreposotory = authorreposotory;
            this.hosting = hosting;
        }
        // GET: BookController
        public ActionResult Index()
        {
            var books = bookreposotory.List();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = bookreposotory.Find(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var model = new bookAutherNewModel
            {
                Authors = filrselectlist()
            };
            return View(model);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(bookAutherNewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string filename = "";
                    if (model.file!=null)
                    {
                        var upload = Path.Combine(hosting.WebRootPath, "uploads");
                        filename = model.file.FileName;
                        string fullpath = Path.Combine(upload,filename);
                        model.file.CopyTo(new FileStream(fullpath,FileMode.Create));
                    }
                    if (model.AutherId == -1)
                    {
                        ViewBag.Message = "Please select an author from the liste";
                        return View(GetAllAuthors());
                    }
                    var auuuthor = authorreposotory.Find(model.AutherId);
                    if (model != null)
                    {
                        Book book = new Book
                        {
                            Id = model.BookId,
                            Title = model.Title,
                            Descreption = model.Descreption,
                            author = auuuthor,
                            ImageUrl=filename

                        };

                        bookreposotory.add(book);
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    
                }

            }
            ModelState.AddModelError("","You have to fill All The Required Fields!");
            return View(GetAllAuthors());
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookreposotory.Find(id);
            var authorId = book.author == null ? book.author.Id = 0 : book.author.Id;
            var viewmodel = new bookAutherNewModel
            {
                BookId = book.Id,
                Title = book.Title,
                Descreption = book.Descreption,
                AutherId = authorId,
                Authors = authorreposotory.List().ToList(),
                ImageUrl=book.ImageUrl
            };
            return View(viewmodel);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(bookAutherNewModel viewmodel)
        {
            try
            {
                string filename = "";
                if (viewmodel.file != null)
                {
                    var upload = Path.Combine(hosting.WebRootPath, "uploads");
                    filename = viewmodel.file.FileName;
                    string fullpath = Path.Combine(upload, filename);
                    //delete the old file
                    string oldfilename = bookreposotory.Find(viewmodel.BookId).ImageUrl;
                    string fulleoldpath = Path.Combine(upload, oldfilename);
                  
                    if (fullpath != fulleoldpath)
                    {
                        System.IO.File.Delete(fullpath);
                        //save the new file
                        viewmodel.file.CopyTo(new FileStream(fullpath, FileMode.Create));

                    }
                }
                var auuuthor = authorreposotory.Find(viewmodel.AutherId);
                Book book = new Book
                { Id=viewmodel.BookId,
                    Title = viewmodel.Title,
                    Descreption = viewmodel.Descreption,
                    author = auuuthor,
                    ImageUrl=filename


                };

                bookreposotory.Update(viewmodel.BookId, book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookreposotory.Find(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                bookreposotory.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        List<Author> filrselectlist()
        {
            var authors = authorreposotory.List().ToList();
            authors.Insert(0, new Author { Id = -1, FullName = "Please select an author ---" });
            return authors;
        
                
         }


        bookAutherNewModel GetAllAuthors()
        {
            var viewmodel = new bookAutherNewModel
            {
                Authors = filrselectlist()
            };
            return viewmodel;
        }
    }
}
