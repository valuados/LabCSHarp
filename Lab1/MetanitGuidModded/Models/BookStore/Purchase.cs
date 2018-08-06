using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetanitGuidModded.Models
{
    public class Purchase
    {
        // Purchase ID
        public int PurchaseId { get; set; }
        // Person Name and Surname
        public string Person { get; set; }
        // Person Adress
        public string Address { get; set; }
        // Book ID
        public int BookId { get; set; }
        // Purchase Date
        public DateTime Date { get; set; }
    }
}