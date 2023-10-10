using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateEverything.Models
{
    public class ItemRating
    {
        /// <summary>
        /// Internal key of comment ID
        /// </summary>
        [Key]
        public int InternalId { get; set; }
        /// <summary>
        /// ID of the item
        /// </summary>
        [ForeignKey("ItemId")]
        public int ItemIdRating { get; set; }

        /// <summary>
        /// ID of the user posting the rating
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Current rating from 1-5, displaye as stars
        /// </summary>
        public int Rating { get; set; }
    }
}
