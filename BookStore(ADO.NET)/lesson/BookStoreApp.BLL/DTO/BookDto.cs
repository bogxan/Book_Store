using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.BLL.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string NameBoook { get; set; }
        public string FIOAuthor { get; set; }
        public string NameIzdat { get; set; }
        public int CountPages { get; set; }
        public string Genre { get; set; }
        public DateTime YearIzdat { get; set; }
        public decimal CostBook { get; set; }
        public decimal PriceBook { get; set; }
    }
}
