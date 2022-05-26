using BookStoreApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.BLL.Interfaces
{
    public interface IBookService
    {
        void AddBook(BookDto book);
        void DeleteBook(int id);
        void UpdateBook(BookDto book);
        List<BookDto> SearchBooksByName(string name);
        List<BookDto> SearchBooksByAuthor(string author);
        List<BookDto> SearchBooksByGenre(string genre);
        List<BookDto> GetNewBooks();
        List<BookDto> GetPopularBooks();
        List<BookDto> GetPopularAuthors();
        List<BookDto> GetPopularGenres();
    }
}
