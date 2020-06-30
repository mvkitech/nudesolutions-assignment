using System;
using Assignment.Core.Repositories;

namespace Assignment.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }

        IItemRepository Items { get; }

        int Commit();
    }
}
