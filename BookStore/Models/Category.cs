using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Kategori No")]
        public int CategoryNo { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public String Name { get; set; }

    }
}
