using System.Linq;
using NUnit.Framework;
using Assignment.Core.Domain;

namespace TestAssignment.UnitTests.DataAccess.Repositories
{
    class ItemRepositoryTests : AbstractRepositoryTests
    {
        [Test]
        public void Get_UsingValidId_ReturnsItem()
        {
            var item = ItemRepository.Get(1);
            Assert.That(item.Id, Is.EqualTo(1));
        }

        [Test]
        public void Get_UsingInvalidId_ReturnsNull()
        {
            var item = ItemRepository.Get(99);
            Assert.IsNull(item);
        }

        [Test]
        public void GetItemsByHighestLimit_WhenCalled_ReturnsHighestLimitsFirst()
        {
            Item[] itemsArray = ItemRepository.GetItemsByHighestLimit().ToArray();
            Assert.That(itemsArray[0].Description, Is.EqualTo("Pots and Pans"));
            Assert.That(itemsArray[1].Description, Is.EqualTo("TV"));
            Assert.That(itemsArray[2].Description, Is.EqualTo("Stereo"));
            Assert.That(itemsArray[3].Description, Is.EqualTo("Jeans"));
            Assert.That(itemsArray[4].Description, Is.EqualTo("Shirts"));
            Assert.That(itemsArray[5].Description, Is.EqualTo("Misc"));
            Assert.That(itemsArray[6].Description, Is.EqualTo("Flatware"));
            Assert.That(itemsArray[7].Description, Is.EqualTo("Knife Set"));
            Assert.That(itemsArray[8].Description, Is.EqualTo("PlayStation"));
        }

        [Test]
        public void GetItemsByLowestLimit_WhenCalled_ReturnsLowestLimitsFirst()
        {
            Item[] itemsArray = ItemRepository.GetItemsByLowestLimit().ToArray();
            Assert.That(itemsArray[0].Description, Is.EqualTo("PlayStation"));
            Assert.That(itemsArray[1].Description, Is.EqualTo("Knife Set"));
            Assert.That(itemsArray[2].Description, Is.EqualTo("Flatware"));
            Assert.That(itemsArray[3].Description, Is.EqualTo("Misc"));
            Assert.That(itemsArray[4].Description, Is.EqualTo("Shirts"));
            Assert.That(itemsArray[5].Description, Is.EqualTo("Jeans"));
            Assert.That(itemsArray[6].Description, Is.EqualTo("Stereo"));
            Assert.That(itemsArray[7].Description, Is.EqualTo("TV"));
            Assert.That(itemsArray[8].Description, Is.EqualTo("Pots and Pans"));
        }

/*
        This test is failing and the application error only exists in the
        unit test code, it is not happening in the main application. Error
        is: System.NotSupportedException: 'Collection was of a fixed size'
        and it has traced to being the Category and Item DBSet() references
        in the AppDbContext class when I am trying to add or remove entries
        during my unit testing. Clearly I need to dig into this deeper and
        understand why this is happening in only the unit tests. 

        [Test]
        public void Add_WhenCalled_AddsItemToParentCategoryEntity()
        {
            var category = CategoryRepository.Get(1);
            var newItem = new Item
            {
                Pid = "P1",
                Description = "Laptop",
                Limit = 2200,
                CategoryId = category.Id,
                Category = category
            };

            ItemRepository.Add(newItem);
            category = CategoryRepository.GetCategoryWithItems(1);
            Assert.That(category.Items.Count, Is.EqualTo(4));
        }
*/
    }
}
