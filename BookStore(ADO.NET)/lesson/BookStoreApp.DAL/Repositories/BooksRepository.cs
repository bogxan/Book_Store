using BookStoreApp.DAL.EF;
using BookStoreApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreApp.DAL.Repositories
{
    public class BooksRepository : BaseRepository<Book>
    {
        public BooksRepository(StoreContext context) : base(context) { }
        public List<Book> SearchBooksByName(string name)
        {
            var result = db.Books.Where(p=>p.NameBoook==name);
            return result.ToList();
        }
        public List<Book> SearchBooksByAuthor(string author)
        {
            var result = db.Books.Where(p => p.FIOAuthor == author);
            return result.ToList();
        }
        public List<Book> SearchBooksByGenre(string genre)
        {
            var result = db.Books.Where(p => p.Genre == genre);
            return result.ToList();
        }
        public List<Book> ShowNewBooks()
        {
            var result = db.Books.FromSqlRaw("SELECT * FROM GetNewBooks()").ToList();
            return result;
        }
        public List<Book> ShowPopularBooks()
        {
            var result = db.Books.FromSqlRaw("SELECT * FROM GetPopularBooks()").ToList();
            return result;
        }
        public List<Book> ShowPopularAuthors()
        {
            var result = db.Books.FromSqlRaw("SELECT * FROM GetPopularAuthor()").ToList();
            return result;
        }
        public List<Book> ShowPopularGenres()
        {
            var result = db.Books.FromSqlRaw("SELECT * FROM GetPopularGenre()").ToList();
            return result;
        }
        public override void Update(Book entity)
        {
            var updateBook = Get(entity.Id);
            updateBook.NameBoook = entity.NameBoook;
            updateBook.NameIzdat = entity.NameIzdat;
            updateBook.PriceBook = entity.PriceBook;
            updateBook.YearIzdat = entity.YearIzdat;
            updateBook.FIOAuthor = entity.FIOAuthor;
            updateBook.Genre = entity.Genre;
            updateBook.CostBook = entity.CostBook;
            updateBook.CountPages = entity.CountPages;
        }
    }
}
