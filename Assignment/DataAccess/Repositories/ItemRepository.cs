using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Assignment.Core.Domain;
using Assignment.Core.Repositories;

namespace Assignment.DataAccess.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(AppDbContext context) : base(context)
        {
        }

        public AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }

        /**
         * Used to extract collection of Items ordered by highest limit.
         * Note: retrieves all Items regardless of Category assignment.
         */
        public IEnumerable<Item> GetItemsByHighestLimit()
        {
            return AppDbContext.Items
                               .OrderByDescending(c => c.Limit)
                               .ToList();
        }

        /**
         * Used to extract collection of Items ordered by lowest limit.
         * Note: retrieves all Items regardless of Category assignment.
         */
        public IEnumerable<Item> GetItemsByLowestLimit()
        {
            return AppDbContext.Items
                               .OrderBy(c => c.Limit)
                               .ToList();
        }
    }
}
