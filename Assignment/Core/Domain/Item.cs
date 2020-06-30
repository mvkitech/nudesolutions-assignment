using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Core.Domain
{
    [Table("Items")]
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Pid { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        public int Limit { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
