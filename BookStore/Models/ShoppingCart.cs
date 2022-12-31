using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class ShoppingCart
    {
        public Product product { get; set; }
        [Range(1,1000)]
        public int count{ get; set; }
    }
}
