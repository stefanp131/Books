using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Books.Models;
using Books.Repositories;
using Books.Entities;

namespace Books.Controllers
{
    public class BookController : Controller
    {
        private IRepository<Book> bookRepository { get; set; }
        private IRepository<Person> personRepository { get; set; }

        public BookController(IRepository<Book> bookRepository, IRepository<Person> personRepository)
        {
            this.bookRepository = bookRepository;
            this.personRepository = personRepository;
        }

        // GET: Book
        public ActionResult Index()
        {
            var listBooksVm = new List<BookViewModel>();
            bookRepository.GetAll().ToList().ForEach(x => listBooksVm.Add(x.MapBook()));
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

                var people = personRepository.GetAll().ToList();
                var person = people.FirstOrDefault(x => x.Name == book.AuthorName);

                if (person != null)
                {
                    person.RoleShelf.Add(book);
                    personRepository.Save();
                }
                else
                {
                    person = new Person { Name = book.AuthorName, Role = Role.Author, Id = 0 };
                    personRepository.AddEntity(person);
                    person.RoleShelf.Add(book);
                    personRepository.Save();
                }

                return RedirectToAction("Index");
            }
            return View(new BookViewModel());
        }

        public ActionResult Details(int id)
        {
            var book = bookRepository.GetEntityById(id).MapBook();
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            var book = bookRepository.GetEntityById(id).MapBook();
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel bookVm)
        {
            if (ModelState.IsValid)
            {
                var book = bookRepository.GetEntityById(bookVm.Id);
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