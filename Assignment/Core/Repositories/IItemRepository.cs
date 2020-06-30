using System.Collections.Generic;
using Assignment.Core.Domain;

namespace Assignment.Core.Repositories
{
    /**
     * Item interface specifying method Repository signatures.
     */
    public interface IItemRepository : IRepository<Item>
    {
        /**
         * Used to extract collection of Items ordered by highest limit.
         * Note: retrieves all Items regardless of Category assignment.
         */
        IEnumerable<Item> GetItemsByHighestLimit();

        /**
         * Used to extract collection of Items ordered by lowest limit.
         * Note: retrieves all Items regardless of Category assignment.
         */
        IEnumerable<Item> GetItemsByLowestLimit();
    }
}
