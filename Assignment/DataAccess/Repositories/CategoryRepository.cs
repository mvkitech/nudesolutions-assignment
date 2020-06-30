using System.Linq;
using Microsoft.EntityFrameworkCore;
using Assignment.Core.Domain;
using Assignment.Core.Repositories;

namespace Assignment.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public AppDbContext AppDbContext
        {
            get { return Context as AppDbContext; }
        }

        /**
         * Used to extract target Category entity with its associated items
         * (if they exist) using the supplied primary key id.
         */
        public Category GetCategoryWithItems(int id)
        {
            return AppDbContext.Categories
                               .Include(c => c.Items)
                               .SingleOrDefault(c => c.Id == id);
        }
    }
}
