using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class AppUser:IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public string? StreetAdress { get; set; }

        public string? City { get; set; }
       
        public string? PostCode { get; set; }
    }
}
