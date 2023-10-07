namespace RateEverything.Models
{
    public class Item
    {
        /// <summary>
        /// ID of the item
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description for the item
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Current rating from 1-5, displaye as stars
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Dictionary of string and int, UserID to Rating Number
        /// </summary>
        public Dictionary<int, int> UserRating { get; set; }

        /// <summary>
        /// Match ID to comment in order to prevent multiple people with same name
        /// without unique identifers
        /// </summary>
        public Dictionary<int, string> Comments { get; set; }
    }
}
