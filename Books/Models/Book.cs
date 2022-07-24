using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Book
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Enter a value bigger than 0")]
        public int ID { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string BookName { get; set; }
        [Display(Name = "Author")]
        [Required]
        public string AuthorName { get; set; }
        [Display(Name = "Category")]
        public Category BookCategory { get; set; }
        [Required]
        public int Price { get; set; }
        [Display(Name = "Condition")]
        [Required]
        public Condition BookCondition { get; set; }
        [Display(Name = "Upload Image")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public string Availability { get; set; }
        public int OrderId { get; set; }
    }
}