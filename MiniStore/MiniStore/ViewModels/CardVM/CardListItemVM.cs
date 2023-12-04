using System.ComponentModel.DataAnnotations;

namespace MiniStore.ViewModels.CardVM
{
    public class CardListItemVM
    {
        public int Id { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
    }
}
