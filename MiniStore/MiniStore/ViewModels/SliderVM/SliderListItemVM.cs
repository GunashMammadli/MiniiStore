using System.ComponentModel.DataAnnotations;

namespace MiniStore.ViewModels.SliderVM
{
    public class SliderListItemVM
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Layer1 { get; set; }
        public string Layer2 { get; set; }
        public string Layer3 { get; set; }
        public string ButtonText { get; set; }
    }
}
