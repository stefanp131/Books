using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Books.Models;
using Books.Repositories;

namespace Books.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository bookRepository { get; set; }
        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        // GET: Book
        public ActionResult Index()
        {
            var listBooksVm = new List<BookViewModel>();
            bookRepository.GetAllBooks().ToList().ForEach(x => listBooksVm.Add(x.MapBook()));
            return View(listBooksVm);
        }

        public ActionResult Create()
        {
            return View(new BookViewModel());
        }

        [HttpPost]
        public ActionResult Create(BookViewModel bookVm)
        {
            if (ModelState.IsValid)
            {
                var book = bookVm.MapBook();
                bookRepository.Add(book);

                return RedirectToAction("Index");
            }
            return View(new BookViewModel());
        }

        public ActionResult Details(int id)
        {
            var book = bookRepository.GetBookById(id).MapBook();
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            var book = bookRepository.GetBookById(id).MapBook();
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel bookVm)
        {
            if (ModelState.IsValid)
            {
                var book = bookRepository.GetBookById(bookVm.Id);
                {
                    book.AuthorName = bookVm.AuthorName;
                    book.Title = bookVm.Title;
                    book.Price = bookVm.Price;
                    book.Category = bookVm.Category;
                }
                bookRepository.Save();
                return RedirectToAction("Index");
            }
            return View(bookVm);
        }

        public ActionResult Delete(int id)
        {
            bookRepository.DeleteById(id);
            return RedirectToAction("Index");
        }

    }
}