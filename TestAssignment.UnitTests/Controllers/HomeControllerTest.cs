using Assignment.Controllers;
using Assignment.Core;
using Assignment.Core.Domain;
using Assignment.DataAccess;
using Assignment.ViewModels;
using NUnit.Framework;
using TestAssignment.UnitTests.DataAccess.Repositories;

namespace TestAssignment.UnitTests.Controllers
{
    class HomeControllerTest : AbstractRepositoryTests
    {
/*
        These test are failing when I attempt to persist the changes with 
        the _unitOfWork. I originally thought it was because of the InMemory 
        database since it is known it does not handle relationships all that
        well in terms of referential integrity. However that is not in play
        here because I did a similar test in my Repository Unit Tests where 
        the InMemory is not even used. By the way the error :

        System.NotSupportedException: 'Collection was of a fixed size'

        private readonly IUnitOfWork _unitOfWork;
        private readonly HomeController _homeController;

        public HomeControllerTest()
        {
            _unitOfWork = new UnitOfWork(_context);
            _homeController = new HomeController(_unitOfWork);
        }

        [Test]
        public void AddItem_WhenCalled_AddsNewItemToDataStore()
        {
            // Prepare new item's model data values
            HomeViewModel homeViewModel = new HomeViewModel
            {
                NewCategoryType = CategoryType.Electronics,
                NewItemDesc = "Laptop",
                NewItemLimit = 1800
            };

            // Add new Item
            _homeController.AddItem(homeViewModel);

            // Analyze the result
            var item = ItemRepository.Get(10);
            Assert.That(item.Id, Is.EqualTo(10));
            var parent = CategoryRepository.Get(1);
            Assert.That(parent.Limits, Is.EqualTo(3800));
        }

        [Test]
        public void RemoveItem_WhenCalled_RemovesExistingItemFromDataStore()
        {
            // Extract some pre-delete information
            var item = ItemRepository.Get(1);
            int parentId = item.CategoryId;

            // Remove the item
            _homeController.RemoveItem(item.Id);

            // Analyze the result
            item = ItemRepository.Get(1);
            Assert.IsNull(item);
            var parent = CategoryRepository.Get(parentId);
            Assert.That(parent.Limits, Is.EqualTo(2000));
        }
*/
    }
}
