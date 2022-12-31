﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        
        [Required]
        public string ISBN { get; set; }
       
        [Required]
        public string Author { get; set; }
       
        [Required]
        public double Price { get; set; }
        
        [ValidateNever]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }


        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

    }
}
