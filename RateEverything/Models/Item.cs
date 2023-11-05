using System.ComponentModel.DataAnnotations;

namespace RateEverything.Models
{
    public class Item
    {
        /// <summary>
        /// ID of the item
        /// </summary>
        [Key]
        public int ItemId { get; set; }

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
        public int Rating { get; set; } = 0;
    }
}
