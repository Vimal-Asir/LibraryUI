using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryUI.Models
{
    public class Book
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Aauthor { get; set; }
        public int Category { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string Publisher { get; set; }
        //public string Image { get; set; }
        public bool IsActive { get; set; }
    }
}