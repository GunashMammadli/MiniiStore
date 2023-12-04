using System.ComponentModel.DataAnnotations;

namespace MiniStore.Models
{
    public class Card
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }

        [Required, MinLength(2), MaxLength(20)]
        public string Title { get; set; }
        
        [Required, MinLength(1)]
        public string Price { get; set; }
    }
}
