using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Assignment.Core.Domain;
using Assignment.Core.Repositories;
using Assignment.DataAccess;
using Assignment.DataAccess.Repositories;

namespace TestAssignment.UnitTests.DataAccess.Repositories
{
    abstract class AbstractRepositoryTests
    {
        protected readonly AppDbContext _context;
        protected readonly ICategoryRepository CategoryRepository;
        protected readonly IItemRepository ItemRepository;

        protected AbstractRepositoryTests()
        {
            // Motivation for handling InMemory DbContext unit testing came from
            // the following video: https://www.youtube.com/watch?v=ddrR440JtiA
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDbContext(options);
            _context.Database.EnsureCreated();
            CategoryRepository = new CategoryRepository(_context);
            ItemRepository = new ItemRepository(_context);

            Seed(_context);
        }

        private void Seed(AppDbContext context)
        {
            ICollection<Category> categories = new HashSet<Category>();

            // Seed the "Electronics" category with some items
            var electronicCategory = new Category() {CategoryType = CategoryType.Electronics, Description = "Electronics", Limits = 4000};
            var electronicItems = new []
            {
                new Item() { Pid="P1", Description = "TV", Limit = 2000 },
                new Item() { Pid="P1", Description = "PlayStation", Limit = 400 },
                new Item() { Pid="P1", Description = "Stereo", Limit = 1600 }
            };
            electronicCategory.Items = electronicItems;
            categories.Add(electronicCategory);

            // Seed the "Clothing" category with some items
            var clothingCategory = new Category() {CategoryType = CategoryType.Clothing, Description = "Clothing", Limits = 2200};
            var clothingItems = new []
            {
                new Item() { Pid="P2", Description = "Shirts", Limit = 1090 },
                new Item() { Pid="P2", Description = "Jeans", Limit = 1110 }
            };
            clothingCategory.Items = clothingItems;
            categories.Add(clothingCategory);

            // Seed the "Kitchen" category with some items
            var kitchenCategory = new Category() {CategoryType = CategoryType.Kitchen, Description = "Kitchen", Limits = 5000};
            var kitchenItems = new []
            {
                new Item() { Pid="P3", Description = "Pots and Pans", Limit = 3000 },
                new Item() { Pid="P3", Description = "Flatware", Limit = 510 },
                new Item() { Pid="P3", Description = "Knife Set", Limit = 490 },
                new Item() { Pid="P3", Description = "Misc", Limit = 1000 }
            };
            kitchenCategory.Items = kitchenItems;
            categories.Add(kitchenCategory);

            // Seed the "Garage" category without any items and setting the type to Kitchen was done on purpose
            var garageCategory = new Category() {CategoryType = CategoryType.Kitchen, Description = "Garage", Limits = 0};
            categories.Add(garageCategory);

            // Save the categories to the InMemory database
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
