using Assignment.Core;
using Assignment.Core.Repositories;
using Assignment.DataAccess.Repositories;

namespace Assignment.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            Items = new ItemRepository(_context);
        }

        public ICategoryRepository Categories { get; set; }

        public IItemRepository Items { get; set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
