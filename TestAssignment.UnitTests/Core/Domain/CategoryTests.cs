using System.Linq;
using NUnit.Framework;
using Assignment.Core.Domain;

namespace TestAssignment.UnitTests.Core.Domain
{
    class CategoryTests
    {
        private readonly Category _category;

        public CategoryTests()
        {
            _category = new Category()
            {
                CategoryType = CategoryType.Electronics,
                Description = "Electronics",
                Limits = 4000
            };
            _category.Items = new []
            {
                new Item() { Description = "TV", Limit = 2000 },
                new Item() { Description = "PlayStation", Limit = 400 },
                new Item() { Description = "Stereo", Limit = 1600 }
            };
        }

        [Test]
        public void GetItemsByHighestLimit_WhenCalled_ReturnsHighestLimitsFirst()
        {
            Item[] itemsArray = _category.GetItemsByHighestLimit().ToArray();
            Assert.That(itemsArray[0].Description, Is.EqualTo("TV"));
            Assert.That(itemsArray[1].Description, Is.EqualTo("Stereo"));
            Assert.That(itemsArray[2].Description, Is.EqualTo("PlayStation"));
        }

        [Test]
        public void GetItemsByLowestLimit_WhenCalled_ReturnsLowestLimitsFirst()
        {
            Item[] itemsArray = _category.GetItemsByLowestLimit().ToArray();
            Assert.That(itemsArray[0].Description, Is.EqualTo("PlayStation"));
            Assert.That(itemsArray[1].Description, Is.EqualTo("Stereo"));
            Assert.That(itemsArray[2].Description, Is.EqualTo("TV"));
        }
    }
}
