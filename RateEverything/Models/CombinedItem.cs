namespace RateEverything.Models
{
    public class CombinedItem
    {
        private Item item;
        private List<ItemRating> itemRatings;

        public CombinedItem(Item item, List<ItemRating> itemRatings)
        {
            this.item = item;
            this.itemRatings = itemRatings;
        }

        public Item CurrentItem { get; set; }
        public List<ItemRating> Ratings { get; set; }
    }
}
