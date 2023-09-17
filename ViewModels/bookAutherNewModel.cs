using bookstore.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.ViewModels
{
    public class bookAutherNewModel
    {
        public int BookId { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string  Title { get; set; }

        [Required]
        [StringLength(120,MinimumLength =5)]
        //Au bien
        //[MaxLength(120)] 
        //[MinLength(5)]
        public string Descreption { get; set; }
        public int AutherId { get; set; }
        public List<Author> Authors { get; set; }

        public IFormFile file { get; set; }
        public string  ImageUrl{ get; set; }

    }
}
