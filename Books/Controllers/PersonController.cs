using Books.Entities;
using Books.Models;
using Books.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class PersonController : Controller
    {
        private IRepository<Person> personRepository { get; set; }
        private IRepository<Book> bookRepository { get; set; }

        public PersonController(IRepository<Person> personRepository, IRepository<Book> bookRepository)
        {
            this.personRepository = personRepository;
            this.bookRepository = bookRepository;
        }
        // GET: Person
        public ActionResult Index()
        {
            var people = new List<PersonViewModel>();            
            personRepository.GetAll().ToList().ForEach(x => people.Add(x.MapPerson()));
            return View(people);
        }

        public ActionResult Create()
        {
            var person = new PersonViewModel();
            return View(person);
        }

        [HttpPost]
        public ActionResult Create(PersonViewModel personVm)
        {
            personRepository.AddEntity(personVm.MapPerson());
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddBook(PersonViewModel personVm)
        {
            return RedirectToAction("Create");
        }
    }
}