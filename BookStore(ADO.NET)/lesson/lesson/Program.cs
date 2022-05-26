using BookStoreApp.BLL.DTO;
using BookStoreApp.BLL.Services;
using BookStoreApp.DAL.Entities;
using BookStoreApp.DAL.Interfaces;
using BookStoreApp.DAL.Repositories;
using System;
using System.Linq;

namespace lesson
{
    class Program
    {
        public static bool Login(AccountsService accountsService)
        {
            Console.WriteLine("Enter login: ");
            string login = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            AccountDto account = new AccountDto { Login = login, Password = password };
            return accountsService.GetAccountByLoginPassword(account);
        }
        public static bool Registration(AccountsService accountsService)
        {
            Console.WriteLine("Enter login: ");
            string login = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            AccountDto account = new AccountDto { Login = login, Password = password };
            if (login.Length >= 4 && password.Length >= 4 && accountsService.GetAccountByLoginPassword(account)==false)
            {
                accountsService.AddAccount(new AccountDto { Login = login, Password = password });
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void App(AccountsService accountsService, OrdersService ordersService, BooksService booksService)
        {
            while (true)
            {
                Console.WriteLine("1 - Add new book");
                Console.WriteLine("2 - Update choosen book");
                Console.WriteLine("3 - Delete choosen book");
                Console.WriteLine("4 - Add new order");
                Console.WriteLine("5 - Search books by name");
                Console.WriteLine("6 - Search books by author");
                Console.WriteLine("7 - Search books by genre");
                Console.WriteLine("8 - Show new books");
                Console.WriteLine("9 - Show the most popular books");
                Console.WriteLine("10 - Show the most popular authors");
                Console.WriteLine("11 - Show the most popular genres");
                Console.WriteLine("12 - Exit");
                int action = int.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        Console.WriteLine("Enter the name of book: ");
                        string nameBook = Console.ReadLine();
                        Console.WriteLine("Enter the author of book: ");
                        string author = Console.ReadLine();
                        Console.WriteLine("Enter the name of publishing house: ");
                        string nameIzdat = Console.ReadLine();
                        Console.WriteLine("Enter the count of pages of book: ");
                        int countPages = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the genre of book: ");
                        string genre = Console.ReadLine();
                        Console.WriteLine("Enter the year of the publishing of book: ");
                        int year = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the month of the publishing of book: ");
                        int month = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the day of the publishing of book: ");
                        int day = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the cost of book: ");
                        decimal cost = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the price of book:");
                        decimal price = decimal.Parse(Console.ReadLine());
                        booksService.AddBook(new BookDto
                        {
                            NameBoook = nameBook,
                            NameIzdat = nameIzdat,
                            CostBook = cost,
                            PriceBook = price,
                            CountPages = countPages,
                            FIOAuthor = author,
                            Genre = genre,
                            YearIzdat = new DateTime(year, month, day)
                        });
                        break;
                    case 2:
                        Console.WriteLine("Enter id of book, that you want to update: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the name of book: ");
                        nameBook = Console.ReadLine();
                        Console.WriteLine("Enter the author of book: ");
                        author = Console.ReadLine();
                        Console.WriteLine("Enter the name of publishing house: ");
                        nameIzdat = Console.ReadLine();
                        Console.WriteLine("Enter the count of pages of book: ");
                        countPages = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the genre of book: ");
                        genre = Console.ReadLine();
                        Console.WriteLine("Enter the year of the publishing of book: ");
                        year = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the month of the publishing of book: ");
                        month = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the day of the publishing of book: ");
                        day = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the cost of book: ");
                        cost = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the price of book:");
                        price = decimal.Parse(Console.ReadLine());
                        BookDto book = new BookDto
                        {
                            Id = id,
                            NameBoook = nameBook,
                            NameIzdat = nameIzdat,
                            CostBook = cost,
                            PriceBook = price,
                            CountPages = countPages,
                            FIOAuthor = author,
                            Genre = genre,
                            YearIzdat = new DateTime(year, month, day)
                        };
                        booksService.UpdateBook(book);
                        break;
                    case 3:
                        Console.WriteLine("Enter id of book, that you want to delete: ");
                        id = int.Parse(Console.ReadLine());
                        booksService.DeleteBook(id);
                        break;
                    case 4:
                        Console.WriteLine("Enter id of the book that you want to order: ");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter count of books that you want to order: ");
                        int count = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter price of order: ");
                        price = int.Parse(Console.ReadLine());
                        OrderDto orderDto = new OrderDto
                        {
                            BookId = id,
                            CountBooks = count,
                            OrderDate = DateTime.Now
                        };
                        ordersService.AddOrder(orderDto);
                        break;
                    case 5:
                        Console.WriteLine("Enter the name of book: ");
                        nameBook = Console.ReadLine();
                        var result = booksService.SearchBooksByName(nameBook);
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Id} {item.NameBoook} {item.FIOAuthor} {item.Genre}");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Enter the author of book: ");
                        author = Console.ReadLine();
                        result = booksService.SearchBooksByAuthor(author);
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Id} {item.NameBoook} {item.FIOAuthor} {item.Genre}");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Enter the genre of book: ");
                        genre = Console.ReadLine();
                        result = booksService.SearchBooksByGenre(genre);
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Id} {item.NameBoook} {item.FIOAuthor} {item.Genre}");
                        }
                        break;
                    case 8:
                        result = booksService.GetNewBooks();
                        foreach (var item in result)
                        {s
                            Console.WriteLine($"{item.Id} {item.NameBoook} {item.FIOAuthor} {item.Genre}");
                        }
                        break;
                    case 9:
                        result = booksService.GetPopularBooks();
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.NameBoook}");
                        }
                        break;
                    case 10:
                        result = booksService.GetPopularAuthors();
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.FIOAuthor}");
                        }
                        break;
                    case 11:
                        result = booksService.GetPopularGenres();
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Genre}");
                        }
                        break;
                    case 12:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            IUnitOfWork uow = new UnitOfWork(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            AccountsService accountsService = new AccountsService(uow);
            OrdersService ordersService = new OrdersService(uow);
            BooksService booksService = new BooksService(uow);
            while (true)
            {
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Registration");
                Console.WriteLine("3 - Exit");
                int action = int.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        if (Login(accountsService)==true)
                        {
                            Console.WriteLine("Authorization successfull!!!");
                            Console.WriteLine("Welcome!");
                            App(accountsService, ordersService, booksService);
                        }
                        else
                        {
                            Console.WriteLine("Lengh of the login and password must be more 4 symbols or such login or password has already used!!! Try again!!!");
                        }
                        break;
                    case 2:
                        if (Registration(accountsService)==true)
                        {
                            Console.WriteLine("Registration successfull!!!");
                        }
                        else
                        {
                            Console.WriteLine("Lengh of the login and password must be more 4 symbols or such login or password has already used!!! Try again!!!");
                        }
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
