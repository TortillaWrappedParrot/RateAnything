using System.Runtime.InteropServices;

namespace RateEverything.Models
{
    /// <summary>
    /// A combinded model consisting of a Item and a list of ItemRating
    /// </summary>
    public class CombinedItem
    {
        /// <summary>
        /// The item passed to the view
        /// </summary>
        public Item CurrentItem { get; set; }
        /// <summary>
        /// The list of ratings passed to the view
        /// </summary>
        public List<ItemRating>? Ratings { get; set; } = new();

        //public ItemRating? NewRating { get; set; }

        public CombinedItem(Item item, List<ItemRating> ratings)
        {
            this.CurrentItem = item;
            this.Ratings = ratings;
        }
    }
}
