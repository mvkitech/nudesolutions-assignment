using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Assignment.Core.Domain
{
    [Table("Categories")]
    public class Category
    {
        public Category()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        public int Limits { get; set; }

        // Tried to use "virtual" here on the Items to prevent them from being lazy loaded
        // but it did not work and I suspect this might be because of the difference between
        // using ASP.NET Core versus the legacy ASP.NET Framework? Not sure, but suspect yes.
        public ICollection<Item> Items { get; set; }

        /**
         * Helper method to extract collection of Items ordered by highest limit.
         */
        public IEnumerable<Item> GetItemsByHighestLimit()
        {
            return Items.OrderByDescending(c => c.Limit).ToList();
        }

        /**
         * Helper method to extract collection of Items ordered by lowest limit.
         */
        public IEnumerable<Item> GetItemsByLowestLimit()
        {
            return Items.OrderBy(c => c.Limit).ToList();
        }
    }
}
