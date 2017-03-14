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
            return View(new PersonViewModel());
        }

        [HttpPost]
        public ActionResult Create(PersonViewModel personVm)
        {
            if (ModelState.IsValid)
            {
                var person = personVm.MapPerson();
                personRepository.AddEntity(person);

                return RedirectToAction("Index");
            }
            return View(new PersonViewModel());
        }

        public ActionResult Details(int id)
        {
            var personVm = personRepository.GetEntityById(id).MapPerson();
            return View(personVm);
        }

        public ActionResult Edit(int id)
        {
            var personVm = personRepository.GetEntityById(id).MapPerson();
            return View(personVm);
        }

        [HttpPost]
        public ActionResult Edit(PersonViewModel personVm)
        {
            var person = personRepository.GetEntityById(personVm.Id);
            {
                person.Name = personVm.Name;
                person.Role = personVm.Role.MapRole();
            }
            personRepository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            personRepository.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}