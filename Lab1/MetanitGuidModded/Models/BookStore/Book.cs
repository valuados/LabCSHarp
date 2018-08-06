using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetanitGuidModded.Models
{
    public class Book
    {
        // Book ID
        public int Id { get; set; }
        // Book Name
        public string Name { get; set; }
        // Book Author
        public string Author { get; set; }
        // Price
        public int Price { get; set; }
    }
}