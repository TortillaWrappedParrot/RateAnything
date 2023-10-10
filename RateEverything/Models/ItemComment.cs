using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateEverything.Models
{
    public class ItemComment
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
        public int ItemIdComment { get; set; }

        /// <summary>
        /// ID of the user posting the comment
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// User's comment as a string
        /// </summary>
        public string Comment { get; set; }
    }
}
