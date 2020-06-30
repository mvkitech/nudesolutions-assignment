using Assignment.Core.Domain;

namespace Assignment.Core.Repositories
{
    /**
     * Category interface specifying method Repository signatures.
     */
    public interface ICategoryRepository : IRepository<Category>
    {
        /**
         * Used to extract target Category entity with its associated items
         * (if they exist) using the supplied primary key id.
         */
        Category GetCategoryWithItems(int id);
    }
}
