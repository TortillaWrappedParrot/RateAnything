using System.Runtime.InteropServices;

namespace RateEverything.Models
{
    public class CombinedItem
    {
        public Item CurrentItem { get; set; }
        public List<ItemRating>? Ratings { get; set; } = new();

        //public ItemRating? NewRating { get; set; }

        public CombinedItem(Item item, List<ItemRating> ratings)
        {
            this.CurrentItem = item;
            this.Ratings = ratings;
        }
    }
}
