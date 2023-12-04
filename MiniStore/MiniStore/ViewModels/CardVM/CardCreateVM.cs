using System.ComponentModel.DataAnnotations;

namespace MiniStore.ViewModels.CardVM
{
    public class CardCreateVM
    {
        [Required]
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }

        [Required, MinLength(2), MaxLength(20)]
        public string Title { get; set; }

        [Required, MinLength(1)]
        public string Price { get; set; }
    }
}
