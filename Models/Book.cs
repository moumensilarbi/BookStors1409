﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descreption { get; set; }
        public string ImageUrl { get; set; }
        public  Author author { get; set; }

    }
}
