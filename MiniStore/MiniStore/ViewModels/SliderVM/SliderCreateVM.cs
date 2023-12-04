using System.ComponentModel.DataAnnotations;

namespace MiniStore.ViewModels.SliderVM
{
    public class SliderCreateVM
    {
        [Required]
        public string ImageUrl { get; set; }

        [Required, MinLength(3), MaxLength(64)]
        public string Layer1 { get; set; }

        [Required, MinLength(3), MaxLength(128)]
        public string Layer2 { get; set; }

        [Required, MinLength(3), MaxLength(128)]
        public string Layer3 { get; set; }

        [Required, MinLength(3), MaxLength(64)]
        public string ButtonText { get; set; }
    }
}
