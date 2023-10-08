using System.ComponentModel.DataAnnotations;

namespace RateEverything.Models
{
    public class Item
    {
        /// <summary>
        /// ID of the item
        /// </summary>
        [Key]
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
        /// String to be seperated, inserted as "ID:#,ID:#"
        /// Split using , then split again using :, this returns the id and the rating
        /// provided
        /// </summary>
        public string UserRating { get; set; }

        /// <summary>
        /// String to be seperated, inserted as "ID:String Comment,ID:String Comment" seperated
        /// using split using , then split again using :
        /// </summary>
        public string Comments { get; set; }
    }
}
