using Books.Entities;
using System.Collections.Generic;

namespace Books.Models
{
    public static class Extensions
    {
        public static BookViewModel MapBook(this Book book)
        {
            var bookVm = new BookViewModel
            {
                Id = book.Id,
                AuthorName = book.AuthorName,
                Price = book.Price,
                Category = book.Category,
                Title = book.Title
            };

            return bookVm;
        }

        public static Book MapBook(this BookViewModel bookVm)
        {
            var book = new Book
            {
                Id = bookVm.Id,
                AuthorName = bookVm.AuthorName,
                Price = bookVm.Price,
                Category = bookVm.Category,
                Title = bookVm.Title
            };

            return book;
        }

        public static PersonViewModel MapPerson(this Person person)
        {
            var personVm = new PersonViewModel {Id = person.Id, Name = person.Name, Role = person.Role.MapRole() };

            return personVm;
        }

        public static Person MapPerson(this PersonViewModel personVm)
        {
            var person = new Person {Id = personVm.Id, Name = personVm.Name, Role = personVm.Role.MapRole() };

            return person;
        }

        public static RoleViewModel MapRole(this Role Role)
        {
            switch (Role)
            {
                case Role.Author: return RoleViewModel.Author;
                case Role.Critic: return RoleViewModel.Critic;
                case Role.Reader: return RoleViewModel.Reader;
                default: return RoleViewModel.Reader;
            }
        }

        public static Role MapRole(this RoleViewModel RoleVm)
        {
            switch (RoleVm)
            {
                case RoleViewModel.Author: return Role.Author;
                case RoleViewModel.Critic: return Role.Critic;
                case RoleViewModel.Reader: return Role.Reader;
                default: return Role.Reader;
            }
        }
    }
}