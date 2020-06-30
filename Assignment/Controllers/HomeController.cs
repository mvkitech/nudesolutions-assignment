using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment.Core;
using Assignment.Core.Domain;
using Assignment.ViewModels;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            int sumOfAllLimits = 0;

            /*
             * This block of code below was necessary because I noticed the "GetAll()" method
             * was lazy loading my collection of Categories where each Item referenced had not
             * yet been loaded which of course is a problem since the UI component being served
             * requires all Categories and their associated Items. I made attempts to fix this
             * in the Category domain entity class (see my comments there) as well as inside
             * of the AppDBContext class (additional comments in there as well). But neither
             * approach worked and I suspect this was because the instruction I was using is
             * based on the legacy ASP.NET Framework while I use ASP.NET Core in this project.
             * Therefore I was forced to use kind of a brute force explicit loading strategy
             * here to get it all to work. I am not caching my results so the if condition
             * used below where I check the item count is not needed. But if the data was cached
             * I felt why would I go fetch the Items if I had them and that is why the if
             * condition is still in the code. There has got to be a better way to have Items
             * eagerly loaded into the Categories (using LINQ and Lambda expressions?) but
             * I'm still in the early days of ASP.NET and there is still so much more to learn. :/
             *
             * Oh and I also piggy backed on this block of code to ensure the sum of all Item limits
             * for all Coverages was properly calculated since I do not store this value in the DB.
             */
            ICollection<Category> categoriesWithTheirItems = new HashSet<Category>();
            IEnumerable<Category> lazyLoadedCategories = _unitOfWork.Categories.GetAll();
            foreach (var category in lazyLoadedCategories)
            {
                var categoryWithItems = category;
                if (category.Items.Count == 0)
                {
                    categoryWithItems = _unitOfWork.Categories.GetCategoryWithItems(category.Id);
                    categoriesWithTheirItems.Add(categoryWithItems);
                }
                sumOfAllLimits = GetSumOfAllItemLimits(categoryWithItems, sumOfAllLimits);
            }

            var homeViewModel = new HomeViewModel()
            {
                Categories = categoriesWithTheirItems,
                SumOfAllLimits = sumOfAllLimits
            };

            return View(homeViewModel);
        }

        [HttpPost]
        public IActionResult AddItem(HomeViewModel homeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(homeViewModel);
            }

            // Need to retrieve Category that the new Item will be assigned to
            var category = GetCategoryByCategoryType(homeViewModel.NewCategoryType);
            if (category != null)
            {
                // Likely not necessary, but still wrapping my head around eager and lazy loading 
                // as GetCategoryByCategoryType() helper function uses the Repository's "GetAll()"
                // which as explained above lazy loads the Category/Item relationship.
                category = _unitOfWork.Categories.Get(category.Id);
                category.Limits += homeViewModel.NewItemLimit;

                // Create new Item and complete Category associations
                var newItem = new Item()
                {
                    Pid = $"P{category.Id}",
                    Description = homeViewModel.NewItemDesc,
                    Limit = homeViewModel.NewItemLimit,
                    CategoryId = category.Id,
                    Category = category
                };

                // Commit new item to our unit of work
                _unitOfWork.Items.Add(newItem);
                _unitOfWork.Commit();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveItem(int id)
        {
            // Deduct item's limit value from parent Category value
            var item = _unitOfWork.Items.Get(id);
            var category = _unitOfWork.Categories.Get(item.CategoryId);
            category.Limits -= item.Limit;

            // Remove the item 
            _unitOfWork.Items.Remove(item);
            _unitOfWork.Commit();

            return RedirectToAction("Index");
        }

        // Created by Microsoft during project creation 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /**
         * Static helper method used to sum limits for each of the possible items.
         */
        private static int GetSumOfAllItemLimits(Category category, int sumOfAllLimits)
        {
            // Enumerate through each category item summing the limits
            var sumOfCategoryLimits = 0;
            foreach (var item in category.Items)
            {
                sumOfCategoryLimits += item.Limit;
            }

            // Reconcile category limits while I am here
            category.Limits = sumOfCategoryLimits;

            // Return sum of all limits
            return sumOfAllLimits + sumOfCategoryLimits;
        }

        /**
         * Helper method used to return the Category associated with
         * the supplied CategoryType parameter.
         */
        private Category GetCategoryByCategoryType(CategoryType targetType)
        {
            foreach (var category in _unitOfWork.Categories.GetAll())
            {
                if (category.CategoryType == targetType)
                {
                    return category;
                }
            }

            return null; // Should probably throw an Exception here since this should
                         // never happen as the Categories are static in this demo.
        }
    }
}
