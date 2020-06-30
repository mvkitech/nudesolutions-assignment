using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Assignment.Core.Domain;

namespace TestAssignment.UnitTests.DataAccess.Repositories
{
    class CategoryRepositoryTests : AbstractRepositoryTests
    {
        [Test]
        public void Get_UsingValidId_ReturnsCategory()
        {
            var category = CategoryRepository.Get(1);
            Assert.That(category.Id, Is.EqualTo(1));
        }

        [Test]
        public void Get_UsingInvalidId_ReturnsNull()
        {
            var category = CategoryRepository.Get(99);
            Assert.IsNull(category);
        }

        [Test]
        public void GetAll_WhenCalled_ReturnsAllCategories()
        {
            IEnumerable<Category> categories = CategoryRepository.GetAll();
            Assert.That(categories.Count(), Is.EqualTo(4));
        }

        [Test]
        public void GetCategoryWithItems_UsingValidId_ReturnsCategoryWithItems()
        {
            var category = CategoryRepository.GetCategoryWithItems(1);
            Assert.That(category.Id, Is.EqualTo(1));
            Assert.That(category.Items.Count, Is.GreaterThan(0));
        }

        [Test]
        public void GetCategoryWithItems_UsingValidId_ReturnsCategoryButNoItems()
        {
            var category = CategoryRepository.GetCategoryWithItems(4);
            Assert.That(category.Id, Is.EqualTo(4));
            Assert.That(category.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetCategoryWithItems_UsingInvalidId_ReturnsNull()
        {
            var category = CategoryRepository.GetCategoryWithItems(-1);
            Assert.That(category, Is.Null);
        }
    }
}
