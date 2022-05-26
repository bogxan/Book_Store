using BookStoreApp.BLL.DTO;
using BookStoreApp.BLL.Interfaces;
using BookStoreApp.DAL.Entities;
using BookStoreApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreApp.BLL.Services
{
    public class BooksService : IBookService
    {
        private IUnitOfWork uow;
        private AutoMapper.ObjectMapper objectManager = AutoMapper.ObjectMapper.Instance;
        public BooksService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void AddBook(BookDto book)
        {
            var result = objectManager.Mapper.Map<Book>(book);
            uow.BooksRepository.Create(result);
            uow.Save();
        }

        public void DeleteBook(int id)
        {
            var result = uow.BooksRepository.Get(id);
            uow.BooksRepository.Delete(result.Id);
            uow.Save();
        }

        public List<BookDto> SearchBooksByAuthor(string author)
        {
            var result = objectManager.Mapper.Map<List<BookDto>>(uow.BooksRepository.SearchBooksByAuthor(author).ToList());
            return result;
        }

        public List<BookDto> SearchBooksByGenre(string genre)
        {
            var result = objectManager.Mapper.Map<List<BookDto>>(uow.BooksRepository.SearchBooksByGenre(genre).ToList());
            return result;
        }

        public List<BookDto> SearchBooksByName(string name)
        {
            var result = objectManager.Mapper.Map<List<BookDto>>(uow.BooksRepository.SearchBooksByName(name).ToList());
            return result;
        }

        public List<BookDto> GetNewBooks()
        {
            var result = objectManager.Mapper.Map<List<BookDto>>(uow.BooksRepository.ShowNewBooks());
            return result;
        }

        public List<BookDto> GetPopularAuthors()
        {
            var result = objectManager.Mapper.Map<List<BookDto>>(uow.BooksRepository.ShowPopularAuthors());
            return result;
        }

        public List<BookDto> GetPopularBooks()
        {
            var result = objectManager.Mapper.Map<List<BookDto>>(uow.BooksRepository.ShowPopularBooks());
            return result;
        }

        public List<BookDto> GetPopularGenres()
        {
            var result = objectManager.Mapper.Map<List<BookDto>>(uow.BooksRepository.ShowPopularGenres());
            return result;
        }

        public void UpdateBook(BookDto book)
        {
            var result = objectManager.Mapper.Map<Book>(book);
            uow.BooksRepository.Update(result);
            uow.Save();
        }
    }
}
